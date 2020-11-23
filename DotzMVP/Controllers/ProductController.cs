using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using DotzMVP.Lib.Exceptions;
using DotzMVP.Lib.Infrastructure.Data.Model;
using DotzMVP.Lib.Services.ProductService;
using DotzMVP.Model.Product;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace DotzMVP.Controllers
{
    [Route("api/v1/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }
        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductRequest productRequest)
        {
            try
            {
                var product = _mapper.Map<Product>(productRequest);
                var response = _mapper.Map<ProductResponse>(await _productService.CreateAsync(product));
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
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Route("list/accessible")]
        [HttpGet]
        public async Task<IActionResult> Accessible()
        {
            List<Expression<Func<Product, object>>> includes = new List<Expression<Func<Product, object>>>()
            {
                x => x.Customer
            };
            Expression<Func<Product, bool>> filter = x => x.IsDeleted == false;
            var response = _mapper.Map<List<ProductResponse>>(await _productService.GetByFilterAsync(filter, includes));
            return Ok(response);
        }
        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> Accessible(Guid id)
        {
            List<Expression<Func<Product, object>>> includes = new List<Expression<Func<Product, object>>>()
            {
                x => x.Customer
            };
            var response = _mapper.Map<ProductResponse>(await _productService.GetByIdAsync(id, includes));
            return Ok(response);
        }
    }
}
