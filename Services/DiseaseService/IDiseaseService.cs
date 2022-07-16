using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using disease_tracker_api.Dtos.Request;
using disease_tracker_api.Dtos.Response;
using disease_tracker_api.Models;

namespace disease_tracker_api.Services.DiseaseService
{
    public interface IDiseaseService
    {
        Task<ServiceResponse<List<DiseaseDTO>>> GetAllDiseases(bool IsArchived);
        Task<ServiceResponse<DiseaseDTO>> GetDiseaseById(int id);
        Task<ServiceResponse<List<DiseaseDTO>>> AddDisease(DiseaseCreateDTO diseaseInput);
        Task<ServiceResponse<DiseaseDTO>> UpdateDisease(int id, DiseaseUpdateDTO diseaseInput);
        Task<ServiceResponse<List<DiseaseDTO>>> DeleteDisease(int id, ArchiveInputDTO archiveInput);
    }
}