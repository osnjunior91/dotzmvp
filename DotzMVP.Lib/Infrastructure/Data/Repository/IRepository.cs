using DotzMVP.Lib.Infrastructure.Data.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotzMVP.Lib.Infrastructure.Data.Repository
{
    public interface IRepository<T> where T : ModelBase
    {
        Task<T> CreateAsync(T item);
    }
}
