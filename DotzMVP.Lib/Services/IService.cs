using DotzMVP.Lib.Infrastructure.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DotzMVP.Lib.Services
{
    public interface IService<T> where T : ModelBase
    {
        Task<T> CreateAsync(T item);
        Task<T> GetByIdAsync(Guid id);
        Task<T> UpdateAsync(T item);
    }
}
