using DotzMVP.Lib.Infrastructure.Data.Model;
using System.Threading.Tasks;

namespace DotzMVP.Lib.Services.AuthService
{
    public interface IAuthService
    {
        Task<string> AuthUserAsync(Login login);
    }
}
