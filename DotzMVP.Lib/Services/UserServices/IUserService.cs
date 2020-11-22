using DotzMVP.Lib.Infrastructure.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DotzMVP.Lib.Services.UserServices
{
    public interface IUserService : IService
    {
        Task<User> CreateAsync(User user);
    }
}
