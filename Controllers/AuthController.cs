using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using disease_tracker_api.Data;
using disease_tracker_api.Dtos.Request;
using disease_tracker_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace disease_tracker_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    
    {
        private readonly IAuthRepository _authRepo;

        public AuthController(IAuthRepository authRepo)
        {
            _authRepo = authRepo;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserRegisterInputDTO request) {
            ServiceResponse<int> response = await _authRepo.Register(
                new User { Email = request.Email}, request.Password
            );

            if(!response.Success)
            {
                return BadRequest(response);
            } 
            return Ok(response);
        }
        
        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserLoginInputDTO request) {
            ServiceResponse<string> response = await _authRepo.Login(
                request.Email, request.Password
            );

            if(!response.Success)
            {
                return BadRequest(response);
            } 
            return Ok(response);
        }        
    }
}