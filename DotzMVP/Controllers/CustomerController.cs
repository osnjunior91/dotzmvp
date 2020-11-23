using System;
using System.Threading.Tasks;
using AutoMapper;
using DotzMVP.Lib.Exceptions;
using DotzMVP.Lib.Infrastructure.Data.Model;
using DotzMVP.Lib.Services.CustomerService;
using DotzMVP.Model.Customer;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DotzMVP.Controllers
{
    [Route("api/v1/customer")]
    [ApiController]
    [Authorize(Roles = "UserAdmin")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }
        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CustomerCreateRequest customerRequest)
        {
            try
            {
                var customer = _mapper.Map<Customer>(customerRequest);
                var response = _mapper.Map<CustomerCreateResponse>(await _customerService.CreateAsync(customer));
                return Ok(response);
            }
            catch(ValidationException ex)
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
