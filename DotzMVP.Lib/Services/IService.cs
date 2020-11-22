using DotzMVP.Lib.Infrastructure.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DotzMVP.Lib.Services
{
    public interface IService<T> where T : ModelBase
    {
        Task<T> CreateAsync(T item);
        Task<T> GetByIdAsync(Guid id, List<Expression<Func<T, object>>> including = null);
        Task<T> UpdateAsync(T item);
        Task<List<T>> GetByFilterAsync(Expression<Func<T, bool>> filter);
    }
}
