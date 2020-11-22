using DotzMVP.Lib.Infrastructure.Data.Model;
using DotzMVP.Lib.Infrastructure.Data.Repository;
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
        public ProductService(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Product> CreateAsync(Product item)
        {
            return await _productRepository.CreateAsync(item);
        }

        public async Task<List<Product>> GetByFilterAsync(Expression<Func<Product, bool>> filter, List<Expression<Func<Product, object>>> including = null)
        {
            return await _productRepository.GetByFilterAsync(filter, including);
        }

        public async Task<Product> GetByIdAsync(Guid id, List<Expression<Func<Product, object>>> including = null)
        {
            return await _productRepository.GetByIdAsync(id);
        }

        public async Task<Product> UpdateAsync(Product item)
        {
            return await _productRepository.UpdateAsync(item);
        }
    }
}
