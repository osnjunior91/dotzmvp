using DotzMVP.Lib.Infrastructure.Data.Context;
using DotzMVP.Lib.Infrastructure.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
            try
            {
                dataset.Add(item);
                await _dataContext.SaveChangesAsync();
                return item;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
