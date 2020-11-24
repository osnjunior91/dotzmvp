using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using DotzMVP.Lib.Exceptions;
using DotzMVP.Lib.Infrastructure.Data.Model;
using DotzMVP.Lib.Services.ChangeService;
using DotzMVP.Lib.Services.UserService;
using DotzMVP.Model.Change;
using DotzMVP.Model.User;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotzMVP.Controllers
{
    [Route("api/v1/user")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;
        private readonly IChangeService _changeService;
        private readonly IMapper _mapper;
        public UserController(IUserService userService, IMapper mapper, IChangeService changeService)
        {
            _userService = userService;
            _mapper = mapper;
            _changeService = changeService;
        }
        /// <summary>
        /// Cadastro de usuario comum.
        /// </summary>
        /// <param name="userRequest">Dados do usuario</param>
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
                var user = _mapper.Map<User>(userRequest);
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
        /// <summary>
        /// Alterar endereço do usuario
        /// </summary>
        /// <param name="addressRequest">Dados do endereço e id do usuario</param>
        /// <returns>Endereço cadastrado</returns>
        [Route("address")]
        [HttpPut]
        [ProducesResponseType(typeof(User), 200)]
        [ProducesResponseType(typeof(string), 422)]
        [ProducesResponseType(typeof(string), 404)]
        [ProducesResponseType(typeof(string), 500)]
        public async Task<IActionResult> RegisterAddress([FromBody] AddressUserRequest addressRequest)
        {
            try
            {
                var address = _mapper.Map<Address>(addressRequest);
                var response = await _userService.UpdateAddressAsync(new User()
                {
                    Id = CurrentUser,
                    Address = address
                });
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return StatusCode(422, ex.Message);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Registrar pontos para usuario
        /// </summary>
        /// <param name="id">Id do usuario</param>
        /// <param name="registerScore">Registro dos pontos</param>
        /// <returns></returns>
        [Route("{id}/score/register")]
        [HttpPost]
        [Authorize(Roles = "UserAdmin")]
        [ProducesResponseType(typeof(Score), 200)]
        [ProducesResponseType(typeof(string), 422)]
        [ProducesResponseType(typeof(string), 404)]
        [ProducesResponseType(typeof(string), 500)]
        public async Task<IActionResult> RegisterScore(Guid id, [FromBody] UserRegisterScoreRequest registerScore)
        {
            try
            {
                var score = _mapper.Map<Score>(registerScore);
                score.PersonID = id;
                var scoreResponse = _mapper.Map<UserRegisterScoreResponse>(await _userService.RegisterScoreUserAsync(score));
                return Ok(scoreResponse);
            }
            catch (ArgumentException ex)
            {
                return StatusCode(422, ex.Message);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        /// <summary>
        /// Listar as trocas feitas pelo cliente
        /// </summary>
        /// <returns>Lista de trocas</returns>
        [Route("list/changes")]
        [HttpGet]
        [Authorize(Roles = "User")]
        [ProducesResponseType(typeof(List<UserChangeListResponse>), 200)]
        [ProducesResponseType(typeof(string), 500)]
        public async Task<IActionResult> Changes()
        {
            List<Expression<Func<ChangeRegister, object>>> includes = new List<Expression<Func<ChangeRegister, object>>>()
            {
                x => x.Itens            
            };
            Expression<Func<ChangeRegister, bool>> filter = x => x.IsDeleted == false && x.PersonID.Equals(CurrentUser);
            var result = _mapper.Map<List<UserChangeListResponse>>(await _changeService.GetByFilterAsync(filter, includes));
            return Ok(result);
        }
    }
}
