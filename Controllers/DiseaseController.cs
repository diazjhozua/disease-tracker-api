using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using disease_tracker_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace disease_tracker_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DiseaseController : ControllerBase
    {

        private static List<Disease> diseases = new List<Disease> {
            new Disease{Name = "Dengue"},
            new Disease{Name = "Covid"},
        };
        public IActionResult Get()
        {
            return Ok(diseases);
        }

    }
}