using DotzMVP.Lib.Infrastructure.Data.Context;
using DotzMVP.Lib.Infrastructure.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

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
    }
}
