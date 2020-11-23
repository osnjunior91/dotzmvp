using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotzMVP.Lib.Infrastructure.Data.Model;
using DotzMVP.Lib.Services.AuthService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotzMVP.Controllers
{
    [Route("api/v1/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] Login login)
        {
            var response = _authService.AuthUserAsync(login);
            return Ok(response);
        }
    }
}
