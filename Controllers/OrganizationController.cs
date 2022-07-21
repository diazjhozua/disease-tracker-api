using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using disease_tracker_api.Components.Handlers;
using disease_tracker_api.Configuration;
using disease_tracker_api.Dtos.Request;
using disease_tracker_api.Dtos.Response;
using disease_tracker_api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Organization_tracker_api.Services.OrganizationService;

namespace disease_tracker_api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class OrganizationController : BaseController
    {
        private readonly IOrganizationService _organizationService;

        public OrganizationController(IOrganizationService organizationService, IHandler handler): base(handler)
        {
            _organizationService = organizationService;
        }    

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _organizationService.GetAllOrganizations(false));
        }

        [HttpGet("archived")]
        public async Task<IActionResult> GetArchived()
        {
            return Ok(await _organizationService.GetAllOrganizations(true));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            ServiceResponse<OrganizationDieseasesDTO> serviceResponse = await _organizationService.GetOrganizationById(id);
            if (serviceResponse.Data == null) return new NotFoundObjectResult(_handler.Utility.FormatObjectResult(404, Entities.Organization, new { id }));
            return Ok(serviceResponse);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] OrganizationInputDTO organizationInput)
        {
            return Ok(await _organizationService.AddOrganization(organizationInput));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] OrganizationInputDTO organizationInput)
        {
            ServiceResponse<OrganizationDTO> serviceResponse = await _organizationService.UpdateOrganization(id, organizationInput);
            if (serviceResponse.Data == null) return new NotFoundObjectResult(_handler.Utility.FormatObjectResult(404, Entities.Organization, new { id }));
            return Ok(serviceResponse);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, [FromBody] ArchiveInputDTO archiveInput)
        {
            ServiceResponse<List<OrganizationDTO>> serviceResponse = await _organizationService.DeleteOrganization(id, archiveInput);
            if (serviceResponse.Data == null) return new NotFoundObjectResult(_handler.Utility.FormatObjectResult(404, Entities.Organization, new { id }));
            return Ok(serviceResponse);
        }
    }
}