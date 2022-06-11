using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using disease_tracker_api.Dtos.Request;
using disease_tracker_api.Dtos.Response;
using dotnet_rpg.Models;

namespace disease_tracker_api.Services.DiseaseService
{
    public interface IDiseaseService
    {
        Task<ServiceResponse<List<DiseaseDTO>>> GetAllDiseases();
        Task<ServiceResponse<DiseaseDTO>> GetDiseaseById(int id);
        Task<ServiceResponse<List<DiseaseDTO>>> AddDisease(DiseaseCreateDTO disease);
        Task<ServiceResponse<DiseaseDTO>> UpdateDisease(int id, DiseaseUpdateDTO disease);
        Task<ServiceResponse<List<DiseaseDTO>>> DeleteDisease(int id);
    }
}