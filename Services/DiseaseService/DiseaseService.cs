using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using disease_tracker_api.Data;
using disease_tracker_api.Dtos.Request;
using disease_tracker_api.Dtos.Response;
using disease_tracker_api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace disease_tracker_api.Services.DiseaseService
{
    public class DiseaseService: IDiseaseService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        
        private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
        
        public DiseaseService(IMapper mapper, DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ServiceResponse<List<DiseaseDTO>>> GetAllDiseases(bool IsArchived)
        {
            ServiceResponse<List<DiseaseDTO>> serviceResponse = new ServiceResponse<List<DiseaseDTO>>();
            List<Disease> dbDiseases = await _context.Diseases.Where(c => c.IsArchived == IsArchived).ToListAsync();
            serviceResponse.Data = (dbDiseases.Select(c => _mapper.Map<DiseaseDTO>(c))).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<DiseaseDTO>> GetDiseaseById(int id)
        {
            ServiceResponse<DiseaseDTO> serviceResponse = new ServiceResponse<DiseaseDTO>();
            Disease dbDisease = await _context.Diseases.FirstOrDefaultAsync(c=> c.Id == id);
            serviceResponse.Data = _mapper.Map<DiseaseDTO>(dbDisease);
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<DiseaseDTO>>> AddDisease(DiseaseCreateDTO diseaseInput)
        {
            ServiceResponse<List<DiseaseDTO>> serviceResponse = new ServiceResponse<List<DiseaseDTO>>();
            Organization organization = await _context.Organizations.FirstOrDefaultAsync(c=> c.Id == diseaseInput.OrganizationId &&  c.User.Id == GetUserId());

            if (organization == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Messsage = "Organization not found";
                return serviceResponse;
            }

            Disease newDisease = new Disease {
                Name = diseaseInput.Name,
                Type = diseaseInput.Type,
                Organization = organization
            };

            await _context.Diseases.AddAsync(newDisease);
            await _context.SaveChangesAsync();
            serviceResponse.Data = (_context.Diseases.Select(c => _mapper.Map<DiseaseDTO>(c))).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<DiseaseDTO>> UpdateDisease(int id, DiseaseUpdateDTO diseaseInput)
        {
            ServiceResponse<DiseaseDTO> serviceResponse = new ServiceResponse<DiseaseDTO>();
                    
            Disease dbDisease = await _context.Diseases.FirstOrDefaultAsync(c => c.Id == id);

            if (dbDisease != null) {
                Organization organization = await _context.Organizations.FirstOrDefaultAsync(c=> c.Id == dbDisease.Organization.Id &&  c.User.Id == GetUserId());
                if (organization != null) 
                {
                    dbDisease.Name = diseaseInput.Name;
                    dbDisease.Type = diseaseInput.Type;
                    dbDisease.DateModified = diseaseInput.DateModified;

                    _context.Diseases.Update(dbDisease);
                    await _context.SaveChangesAsync();

                    serviceResponse.Data = _mapper.Map<DiseaseDTO>(dbDisease);
                }
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<DiseaseDTO>>> DeleteDisease(int id, ArchiveInputDTO archiveInput)
        {
            ServiceResponse<List<DiseaseDTO>> serviceResponse = new ServiceResponse<List<DiseaseDTO>>();
            Disease dbDisease = await _context.Diseases.FirstOrDefaultAsync(c => c.Id == id);

            if(dbDisease != null)
            {
                Organization organization = await _context.Organizations.FirstOrDefaultAsync(c=> c.Id == dbDisease.Organization.Id &&  c.User.Id == GetUserId());
                
                if (organization != null) 
                {
                    dbDisease.IsArchived = archiveInput.IsArchived;
                    if (archiveInput.IsArchived) dbDisease.ArchiveReason = archiveInput.ArchiveReason;

                    _context.Diseases.Update(dbDisease);

                    bool isFromDeletePage = archiveInput.IsArchived ?  false : true;
                    await _context.SaveChangesAsync();

                    serviceResponse.Data = (_context.Diseases.Where(c => c.IsArchived == isFromDeletePage)
                        .Select(c => _mapper.Map<DiseaseDTO>(c))).ToList();

                    serviceResponse.Messsage = (archiveInput.IsArchived) ?  "Succesfully marked as Archived" : "Successfully restored";
                }
            }
            return serviceResponse;
        }
    }
}