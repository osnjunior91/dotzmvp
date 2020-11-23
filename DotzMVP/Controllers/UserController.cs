using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DotzMVP.Lib.Exceptions;
using DotzMVP.Lib.Infrastructure.Data.Model;
using DotzMVP.Lib.Services.UserService;
using DotzMVP.Model.User;
using FluentValidation;
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

        [Route("{id}/address")]
        [HttpPost]
        public async Task<IActionResult> RegisterAddress(Guid id, [FromBody] AddressUserRequest addressRequest)
        {
            try
            {
                var address = _mapper.Map<Address>(addressRequest);
                var response = await _userService.UpdateAddressAsync(new User()
                {
                    Id = id,
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

        [Route("{id}/score/register")]
        [HttpPost]
        public async Task<IActionResult> RegisterScore(Guid id, [FromBody] UserRegisterScoreRequest registerScore)
        {
            try
            {
                var score = _mapper.Map<Score>(registerScore);
                score.PersonID = id;
                var scoreResponse = await _userService.RegisterScoreUserAsync(score);
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

    }
}
