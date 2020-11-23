using DotzMVP.Lib.Infrastructure.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DotzMVP.Lib.Services.ChangeService
{
    public class ChangeService : IChangeService
    {
        public Task<ChangeRegister> CreateAsync(ChangeRegister item)
        {
            throw new NotImplementedException();
        }

        public Task<List<ChangeRegister>> GetByFilterAsync(Expression<Func<ChangeRegister, bool>> filter, List<Expression<Func<ChangeRegister, object>>> including = null)
        {
            throw new NotImplementedException();
        }

        public Task<ChangeRegister> GetByIdAsync(Guid id, List<Expression<Func<ChangeRegister, object>>> including = null)
        {

            throw new NotImplementedException();
        }

        public Task<ChangeRegister> UpdateAsync(ChangeRegister item)
        {
            throw new NotImplementedException();
        }
    }
}
