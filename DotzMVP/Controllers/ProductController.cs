using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using DotzMVP.Lib.Infrastructure.Data.Model;
using DotzMVP.Lib.Services.ProductService;
using DotzMVP.Model.Product;
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
            var product = _mapper.Map<Product>(productRequest);
            var response = await _productService.CreateAsync(product);
            return Ok(response);
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
            var response = await _productService.GetByFilterAsync(filter, includes  );
            return Ok(response);
        }
    }
}
