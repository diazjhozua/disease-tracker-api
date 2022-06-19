using System.Linq;
using AutoMapper;
using disease_tracker_api.Dtos.Request;
using disease_tracker_api.Dtos.Response;
using disease_tracker_api.Models;

namespace dotnet_rpg
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Disease, DiseaseDTO>();
            CreateMap<DiseaseCreateDTO, Disease>();
            CreateMap<Organization, OrganizationDTO>();
            CreateMap<OrganizationInputDTO, Organization>();
        }
    }
}