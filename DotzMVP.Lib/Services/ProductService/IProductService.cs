using DotzMVP.Lib.Infrastructure.Data.Model;
using System;
using System.Threading.Tasks;

namespace DotzMVP.Lib.Services.ProductService
{
    public interface IProductService : IService<Product>
    {
        Task<Product> DeleteAsync(Guid id);
    }
}
