using DotzMVP.Lib.Infrastructure.Data.Context;
using DotzMVP.Lib.Infrastructure.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DotzMVP.Lib.Infrastructure.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : ModelBase
    {
        private readonly DataContext _dataContext;
        private DbSet<T> dataset;
        public Repository(DataContext dataContext)
        {
            _dataContext = dataContext;
            dataset = dataContext.Set<T>();
        }

        public async Task<T> CreateAsync(T item)
        {
            dataset.Add(item);
            await _dataContext.SaveChangesAsync();
            return item;
        }

        public async Task<T> GetByIdAsync(Guid id, List<Expression<Func<T, object>>> including = null)
        {
            var query = dataset.AsQueryable();
            if (including != null)
                including.ForEach(include =>
                {
                    if (include != null)
                        query = query.Include(include);
                });
            return await query.SingleOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<T> UpdateAsync(T item)
        {
            dataset.Update(item);
            await _dataContext.SaveChangesAsync();
            return item;
        }
    }
}
