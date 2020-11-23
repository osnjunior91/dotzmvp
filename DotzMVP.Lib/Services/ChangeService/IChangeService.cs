using DotzMVP.Lib.Infrastructure.Data.Model;
using System;
using System.Threading.Tasks;

namespace DotzMVP.Lib.Services.ChangeService
{
    public interface IChangeService : IService<ChangeRegister>
    {
        public Task<ChangeRegister> UpdateStatusAsync(Guid changeId, StatusChange status);
    }
}
