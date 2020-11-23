using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DotzMVP.Lib.Exceptions;
using DotzMVP.Lib.Infrastructure.Data.Model;
using DotzMVP.Lib.Services.ChangeService;
using DotzMVP.Model.Change;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotzMVP.Controllers
{
    [Route("api/v1/change")]
    [ApiController]
    public class ChangeController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IChangeService _changeService;
        public ChangeController(IMapper mapper, IChangeService changeService)
        {
            _mapper = mapper;
            _changeService = changeService;
        }
        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ChangeCreateRequest changeRequest)
        {
            try
            {
                var change = _mapper.Map<ChangeRegister>(changeRequest);
                var changeResult = await _changeService.CreateAsync(change);
                return Ok(changeResult);
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
