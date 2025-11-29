using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.Domain.Contract;
using Store.Shared.Dtos.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Store.Presentation
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController(IServiceManager _serviceManager) : ControllerBase
    {
        //login
        [HttpPost("login")] //POST : baseUrl/api/auth/login
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            var result = await _serviceManager.AuthService.LoginAsync(loginRequest);
            return Ok(result);
        }


        //register
        [HttpPost("register")] //POST : baseUrl/api/auth/login
        public async Task<IActionResult> Register(RegisterRequest registerRequest)
        {
            var result = await _serviceManager.AuthService.RegisterAsync(registerRequest);
            return Ok(result);
        }

        //Check Email Exists
        [HttpGet("EmailExists")]
        public async Task<IActionResult> CheckEmailExists(string email)
        {
            var result = await _serviceManager.AuthService.CheckEmailExistAsync(email);
            return Ok(result);
        }

        //Get Current User
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetCurrentUser()
        {
            var email = User.FindFirst(ClaimTypes.Email);
            var result = await _serviceManager.AuthService.GetCurrentUserAsync(email.Value);
            return Ok(result);
        }

        //Get Current User Address
        [HttpGet("address")]
        [Authorize]
        public async Task<IActionResult> GetCurrentUserAddress()
        {
            var email = User.FindFirst(ClaimTypes.Email);
            var result = await _serviceManager.AuthService.GetCurrentUserAddressAsync(email.Value);
            return Ok(result);
        }

        //Update Current User Address
        [HttpPut("address")]
        [Authorize]
        public async Task<IActionResult> UpdateCurrentUserAddress(AddressDto request)
        {
            var email = User.FindFirst(ClaimTypes.Email);
            var result = await _serviceManager.AuthService.UpdateCurrentUserAddressAsync(request, email.Value);
            return Ok(result);
        }
    }
}
