using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using DotzMVP.Lib.Exceptions;
using DotzMVP.Lib.Infrastructure.Data.Model;
using DotzMVP.Lib.Services.ProductService;
using DotzMVP.Model.Product;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DotzMVP.Controllers
{
    [Route("api/v1/product")]
    [ApiController]
    [Authorize]
    public class ProductController : BaseController
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }
        /// <summary>
        /// Cadastro de novos produtos
        /// </summary>
        /// <param name="productRequest">Dados do produto a ser cadastrado</param>
        /// <returns>Dados do produto cadastrado</returns>
        [Route("create")]
        [HttpPost]
        [Authorize(Roles = "UserAdmin")]
        [ProducesResponseType(typeof(ProductResponse), 200)]
        [ProducesResponseType(typeof(string), 422)]
        [ProducesResponseType(typeof(string), 404)]
        [ProducesResponseType(typeof(string), 500)]
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

        /// <summary>
        /// Lista de produtos disponiveispara troca
        /// </summary>
        /// <returns>Lista de produtos</returns>
        [Route("list/accessible")]
        [HttpGet]
        [ProducesResponseType(typeof(List<ProductResponse>), 200)]
        [ProducesResponseType(typeof(string), 500)]
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
        /// <summary>
        /// Detalhamento do produto
        /// </summary>
        /// <param name="id">Id do produto</param>
        /// <returns>Produto</returns>
        [Route("{id}")]
        [HttpGet]
        [ProducesResponseType(typeof(ProductResponse), 200)]
        [ProducesResponseType(typeof(string), 500)]
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
