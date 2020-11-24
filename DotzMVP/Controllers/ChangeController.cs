using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DotzMVP.Lib.Exceptions;
using DotzMVP.Lib.Infrastructure.Data.Model;
using DotzMVP.Lib.Services.ChangeService;
using DotzMVP.Model.Change;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotzMVP.Controllers
{
    /// <summary>
    /// Operações de trocas
    /// </summary>
    [Route("api/v1/change")]
    [ApiController]
    public class ChangeController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IChangeService _changeService;
        public ChangeController(IMapper mapper, IChangeService changeService)
        {
            _mapper = mapper;
            _changeService = changeService;
        }
        /// <summary>
        /// Criar uma nova operação de troca de pontos
        /// </summary>
        /// <param name="changeRequest">Parametros para troca</param>
        /// <returns>Dados da operação</returns>
        [Route("create")]
        [HttpPost]
        [Authorize]
        [ProducesResponseType(typeof(ChangeCreateResponse), 200)]
        [ProducesResponseType(typeof(string), 422)]
        [ProducesResponseType(typeof(string), 404)]
        [ProducesResponseType(typeof(string), 500)]
        public async Task<IActionResult> Create([FromBody] ChangeCreateRequest changeRequest)
        {
            try
            {
                var change = _mapper.Map<ChangeRegister>(changeRequest);
                change.PersonID = CurrentUser;
                var changeResult = _mapper.Map<ChangeCreateResponse>(await _changeService.CreateAsync(change));
                return Ok(changeResult);
            }
            catch (ValidationException ex)
            {
                return StatusCode(422, ex.Message);
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
    }
}
