using DotzMVP.Lib.Infrastructure.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DotzMVP.Lib.Services.ProductService
{
    public interface IProductService : IService<Product>
    {
        Task<Product> DeleteAsync(Guid id);
        Task<List<Product>> GetAllAsync(List<Expression<Func<Product, object>>> including = null);
    }
}
