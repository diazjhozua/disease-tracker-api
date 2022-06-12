using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using disease_tracker_api.Data;
using disease_tracker_api.Dtos.Request;
using disease_tracker_api.Dtos.Response;
using disease_tracker_api.Models;
using dotnet_rpg.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace disease_tracker_api.Services.DiseaseService
{
    public class DiseaseService: IDiseaseService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        
        public DiseaseService(IMapper mapper, DataContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<DiseaseDTO>>> GetAllDiseases()
        {
            ServiceResponse<List<DiseaseDTO>> serviceResponse = new ServiceResponse<List<DiseaseDTO>>();
            List<Disease> dbDiseases = await _context.Diseases.ToListAsync();

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

        public async Task<ServiceResponse<List<DiseaseDTO>>> AddDisease(DiseaseCreateDTO disease)
        {
            ServiceResponse<List<DiseaseDTO>> serviceResponse = new ServiceResponse<List<DiseaseDTO>>();
            Disease newDisease = _mapper.Map<Disease>(disease);
            await _context.Diseases.AddAsync(newDisease);
            await _context.SaveChangesAsync();
            serviceResponse.Data = (_context.Diseases.Select(c => _mapper.Map<DiseaseDTO>(c))).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<DiseaseDTO>> UpdateDisease(int id, DiseaseUpdateDTO disease)
        {
            ServiceResponse<DiseaseDTO> serviceResponse = new ServiceResponse<DiseaseDTO>();
                    
            Disease fetchDisease = await _context.Diseases.FirstOrDefaultAsync(c => c.Id == id);
            
            if (fetchDisease != null) 
            {
                fetchDisease.Name = disease.Name;
                fetchDisease.Type = disease.Type;
                fetchDisease.DateModified = disease.DateModified;

                _context.Diseases.Update(fetchDisease);
                await _context.SaveChangesAsync();

                serviceResponse.Data = _mapper.Map<DiseaseDTO>(fetchDisease);
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<DiseaseDTO>>> DeleteDisease(int id)
        {
            ServiceResponse<List<DiseaseDTO>> serviceResponse = new ServiceResponse<List<DiseaseDTO>>();

            Disease disease = await _context.Diseases.FirstOrDefaultAsync(c => c.Id == id);
            if(disease != null)
            {
                _context.Diseases.Remove(disease);
                await _context.SaveChangesAsync();
                serviceResponse.Data = (_context.Diseases.Select(c => _mapper.Map<DiseaseDTO>(c))).ToList();
                serviceResponse.Messsage = "Disease successfully deleted";
            }
            return serviceResponse;
        }
    }
}