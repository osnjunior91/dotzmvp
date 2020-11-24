using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        /// <summary>
        /// Endpoint usado para autenticação na aplicação.
        /// </summary>
        /// <param name="login">Usuário e senha da aplicação</param>
        /// <returns>JWT Token</returns>
        [Route("login")]
        [HttpPost]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(string), 422)]
        [ProducesResponseType(typeof(string), 500)]
        public async Task<IActionResult> Login([FromBody] Login login)
        {
            try
            {
                var response = await _authService.AuthUserAsync(login);
                return Ok(response);
            }
            catch (ValidationException ex)
            {
                return StatusCode(422, ex.Message);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
