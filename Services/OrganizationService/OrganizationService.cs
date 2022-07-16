using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using disease_tracker_api.Models;
using Microsoft.EntityFrameworkCore;
using disease_tracker_api.Dtos.Response;
using disease_tracker_api.Dtos.Request;
using disease_tracker_api.Data;

namespace Organization_tracker_api.Services.OrganizationService
{
    public class OrganizationService : IOrganizationService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public OrganizationService(IMapper mapper, DataContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<OrganizationDTO>>> GetAllOrganizations(bool IsArchived)
        {
            ServiceResponse<List<OrganizationDTO>> serviceResponse = new ServiceResponse<List<OrganizationDTO>>();
            List<Organization> dbOrganizations = await _context.Organizations.Where(c => c.IsArchived == IsArchived).ToListAsync();
            serviceResponse.Data = (dbOrganizations.Select(c => _mapper.Map<OrganizationDTO>(c))).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<OrganizationDTO>> GetOrganizationById(int id)
        {
            ServiceResponse<OrganizationDTO> serviceResponse = new ServiceResponse<OrganizationDTO>();
            Organization dbOrganization = await _context.Organizations.FirstOrDefaultAsync(c=> c.Id == id);
            serviceResponse.Data = _mapper.Map<OrganizationDTO>(dbOrganization);
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<OrganizationDTO>>> AddOrganization(OrganizationInputDTO organizationInput)
        {
            ServiceResponse<List<OrganizationDTO>> serviceResponse = new ServiceResponse<List<OrganizationDTO>>();
            Organization newOrganization = _mapper.Map<Organization>(organizationInput);
            await _context.Organizations.AddAsync(newOrganization);
            await _context.SaveChangesAsync();
            serviceResponse.Data = (_context.Organizations.Select(c => _mapper.Map<OrganizationDTO>(c))).ToList();
            return serviceResponse;
        }
        public async Task<ServiceResponse<OrganizationDTO>> UpdateOrganization(int id, OrganizationInputDTO organizationInput)
        {
            ServiceResponse<OrganizationDTO> serviceResponse = new ServiceResponse<OrganizationDTO>();
                    
            Organization dbOrganization = await _context.Organizations.FirstOrDefaultAsync(c => c.Id == id);
            
            if (dbOrganization != null) 
            {
                dbOrganization.Name = organizationInput.Name;
                dbOrganization.Email = organizationInput.Email;
                dbOrganization.MobileNo = organizationInput.MobileNo;
                if (organizationInput.Region != null) dbOrganization.Region = organizationInput.Region;
                if (organizationInput.Country != null) dbOrganization.Country = organizationInput.Country;
                if (organizationInput.City != null) dbOrganization.City = organizationInput.City;
                if (organizationInput.Province != null) dbOrganization.Province = organizationInput.Province;
                if (organizationInput.ZipCode != 0) dbOrganization.ZipCode = organizationInput.ZipCode;
                dbOrganization.DateModified = DateTime.Now;

                _context.Organizations.Update(dbOrganization);
                await _context.SaveChangesAsync();

                serviceResponse.Data = _mapper.Map<OrganizationDTO>(dbOrganization);
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<OrganizationDTO>>> DeleteOrganization(int id, ArchiveInputDTO archiveInput)
        {
            ServiceResponse<List<OrganizationDTO>> serviceResponse = new ServiceResponse<List<OrganizationDTO>>();

            Organization dbOrganization = await _context.Organizations.FirstOrDefaultAsync(c => c.Id == id);
            if(dbOrganization != null)
            {
                dbOrganization.IsArchived = archiveInput.IsArchived;
                if (archiveInput.IsArchived) dbOrganization.ArchiveReason = archiveInput.ArchiveReason;

                _context.Organizations.Update(dbOrganization);

                bool isFromDeletePage = archiveInput.IsArchived ?  false : true;
                await _context.SaveChangesAsync();

                serviceResponse.Data = (_context.Organizations.Where(c => c.IsArchived == isFromDeletePage)
                    .Select(c => _mapper.Map<OrganizationDTO>(c))).ToList();

                serviceResponse.Messsage = (archiveInput.IsArchived) ?  "Succesfully marked as Archived" : "Successfully restored";
            }
            return serviceResponse;
        }


    }
}