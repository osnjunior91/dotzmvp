using DotzMVP.Lib.Infrastructure.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DotzMVP.Lib.Infrastructure.Data.Repository
{
    public interface IRepository<T> where T : ModelBase
    {
        Task<T> CreateAsync(T item);
        Task<T> GetByIdAsync(Guid id, List<Expression<Func<T, object>>> including = null);
        Task<T> UpdateAsync(T item);
        Task<List<T>> GetByFilterAsync(Expression<Func<T, bool>> filter);
    }
}
