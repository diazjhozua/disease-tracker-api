using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using disease_tracker_api.Models;
using disease_tracker_api.Dtos.Response;
using disease_tracker_api.Dtos.Request;

namespace Organization_tracker_api.Services.OrganizationService
{
    public interface IOrganizationService
    {
        Task<ServiceResponse<List<OrganizationDTO>>> GetAllOrganizations(bool IsArchived);
        Task<ServiceResponse<OrganizationDieseasesDTO>> GetOrganizationById(int id);
        Task<ServiceResponse<List<OrganizationDTO>>> AddOrganization(OrganizationInputDTO organizationInput);
        Task<ServiceResponse<OrganizationDTO>> UpdateOrganization(int id, OrganizationInputDTO organizationInput);
        Task<ServiceResponse<List<OrganizationDTO>>> DeleteOrganization(int id, ArchiveInputDTO archiveInput);
    }
}