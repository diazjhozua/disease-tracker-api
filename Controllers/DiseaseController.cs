using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using disease_tracker_api.Components.Handlers;
using disease_tracker_api.Configuration;
using disease_tracker_api.Dtos.Request;
using disease_tracker_api.Dtos.Response;
using disease_tracker_api.Models;
using disease_tracker_api.Services.DiseaseService;
using dotnet_rpg.Models;
using Microsoft.AspNetCore.Mvc;

namespace disease_tracker_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DiseaseController : BaseController
    {

        private readonly IDiseaseService _diseaseService;

        public DiseaseController(IDiseaseService diseaseService, IHandler handler): base(handler)
        {
            _diseaseService = diseaseService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _diseaseService.GetAllDiseases(false));
        }

        [HttpGet("archived")]
        public async Task<IActionResult> GetArchived()
        {
            return Ok(await _diseaseService.GetAllDiseases(true));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            ServiceResponse<DiseaseDTO> response = await _diseaseService.GetDiseaseById(id);
            if (response.Data == null) return new NotFoundObjectResult(_handler.Utility.FormatObjectResult(404, Entities.Disease, new { id }));
            return Ok(response);
        }

        [HttpGet("create")]
        public IActionResult GetCreate()
        {
            Dictionary<string,int> enumValue = ((DiseaseType[])Enum.GetValues(typeof(DiseaseType))).ToDictionary(k => _handler.Utility.SplitCamelCase(k.ToString()), v => (int)v);
            return Ok(enumValue);
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DiseaseCreateDTO disease)
        {
            return Ok(await _diseaseService.AddDisease(disease));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] DiseaseUpdateDTO disease)
        {
            ServiceResponse<DiseaseDTO> response = await _diseaseService.UpdateDisease(id, disease);
            if (response.Data == null) return new NotFoundObjectResult(_handler.Utility.FormatObjectResult(404, Entities.Disease, new { id }));
            return Ok(await _diseaseService.UpdateDisease(id, disease));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, [FromBody] ArchiveInputDTO archiveInput)
        {
            ServiceResponse<List<DiseaseDTO>> response = await _diseaseService.DeleteDisease(id, archiveInput);
            if (response.Data == null) return new NotFoundObjectResult(_handler.Utility.FormatObjectResult(404, Entities.Disease, new { id }));
            return Ok(response);
        }
    }
}