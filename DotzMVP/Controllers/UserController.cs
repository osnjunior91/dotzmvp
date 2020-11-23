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

        [Route("address")]
        [HttpPost]
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

        [Route("{id}/score/register")]
        [HttpPost]
        [Authorize(Roles = "UserAdmin")]
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
        [Route("list/changes")]
        [HttpGet]
        [Authorize(Roles = "User")]
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
