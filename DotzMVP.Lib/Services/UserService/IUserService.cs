using DotzMVP.Lib.Infrastructure.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DotzMVP.Lib.Services.UserService
{
    public interface IUserService: IService<User>
    {
        Task<User> UpdateAddressAsync(User user);
        Task<Score> RegisterScoreUserAsync(Score score);
    }
}
