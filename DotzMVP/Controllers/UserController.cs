using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DotzMVP.Lib.Infrastructure.Data.Model;
using DotzMVP.Lib.Services.UserServices;
using DotzMVP.Model.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotzMVP.Controllers
{
    [Route("api/v1/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserRequest userRequest)
        {
            var user = _mapper.Map<User>(userRequest);
            var response = await _userService.CreateAsync(user);
            return Ok(response);
        }

    }
}
