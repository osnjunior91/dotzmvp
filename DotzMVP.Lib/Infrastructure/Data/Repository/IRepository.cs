using DotzMVP.Lib.Infrastructure.Data.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotzMVP.Lib.Infrastructure.Data.Repository
{
    public interface IRepository<T> where T : ModelBase
    {
        Task<T> CreateAsync(T item);
        Task<T> GetByIdAsync(Guid id);
        Task<T> UpdateAsync(T item);
    }
}
