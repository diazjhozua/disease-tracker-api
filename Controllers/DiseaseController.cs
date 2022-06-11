using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class DiseaseController : ControllerBase
    {

        private readonly IDiseaseService _diseaseService;

        public DiseaseController(IDiseaseService diseaseService)
        {
            _diseaseService = diseaseService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _diseaseService.GetAllDiseases());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _diseaseService.GetDiseaseById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DiseaseCreateDTO disease)
        {
            return Ok(await _diseaseService.AddDisease(disease));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] DiseaseUpdateDTO disease)
        {
            return Ok(await _diseaseService.UpdateDisease(id, disease));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            ServiceResponse<List<DiseaseDTO>> response = await _diseaseService.DeleteDisease(id);
            if (response.Data == null) {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}