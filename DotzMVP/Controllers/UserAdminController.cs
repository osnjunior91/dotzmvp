using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using DotzMVP.Lib.Infrastructure.Data.Model;
using DotzMVP.Lib.Services.ChangeService;
using DotzMVP.Lib.Services.UserAdminService;
using DotzMVP.Model.Change;
using DotzMVP.Model.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotzMVP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAdminController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IChangeService _changeService;
        private readonly IUserAdminService _userService;

        public UserAdminController(IMapper mapper, IChangeService changeService, IUserAdminService userService)
        {
            _mapper = mapper;
            _changeService = changeService;
            _userService = userService;
        }
        /// <summary>
        /// Criação de usuario administrador
        /// </summary>
        /// <param name="userRequest">Dados do adinistrador</param>
        /// <returns>Usuario cadastrado</returns>
        [Route("create")]
        [HttpPost]
        [ProducesResponseType(typeof(UserCreateResponse), 200)]
        [ProducesResponseType(typeof(string), 422)]
        [ProducesResponseType(typeof(string), 500)]
        public async Task<IActionResult> Create([FromBody] UserCreateRequest userRequest)
        {
            try
            {
                var user = _mapper.Map<UserAdmin>(userRequest);
                var response = _mapper.Map<UserCreateResponse>(await _userService.CreateAsync(user));
                return Ok(response);
            }
            catch (ValidationException ex)
            {
                return StatusCode(422, ex.Message);
            }
            catch (ArgumentException ex)
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
