using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DotzMVP.Lib.Infrastructure.Data.Model;
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
        public ChangeController(IMapper mapper)
        {
            _mapper = mapper;
        }
        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ChangeCreateRequest changeRequest)
        {
            var change = _mapper.Map<ChangeRegister>(changeRequest);
            return Ok();
        }
    }
}
