using DotzMVP.Lib.Exceptions;
using DotzMVP.Lib.Infrastructure.Data.Model;
using DotzMVP.Lib.Infrastructure.Data.Repository;
using DotzMVP.Lib.Infrastructure.Validator;
using DotzMVP.Lib.Services.CustomerService;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DotzMVP.Lib.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productRepository;
        private readonly ICustomerService _customerService;
        public ProductService(IRepository<Product> productRepository, ICustomerService customerService)
        {
            _productRepository = productRepository;
            _customerService = customerService;
        }
        public async Task<Product> CreateAsync(Product item)
        {
            await ValidateProductAsync(item);
            return await _productRepository.CreateAsync(item);
        }

        public async Task<Product> DeleteAsync(Guid id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
                throw new NotFoundException("Product Not Found");
            product.IsDeleted = true;
            return await UpdateAsync(product);
        }

        public async Task<List<Product>> GetByFilterAsync(Expression<Func<Product, bool>> filter, List<Expression<Func<Product, object>>> including = null)
        {
            return await _productRepository.GetByFilterAsync(filter, including);
        }

        public async Task<Product> GetByIdAsync(Guid id, List<Expression<Func<Product, object>>> including = null)
        {
            return await _productRepository.GetByIdAsync(id, including);
        }

        public async Task<Product> UpdateAsync(Product item)
        {
            await ValidateProductAsync(item);
            return await _productRepository.UpdateAsync(item);
        }

        private async Task ValidateProductAsync(Product item)
        {
            var customer = await _customerService.GetByIdAsync(item.CustomerID);
            if (customer == null)
                throw new NotFoundException("Customer Not Found");
            var validator = new ProductValidator();
            validator.ValidateAndThrow(item);
        }
    }
}
