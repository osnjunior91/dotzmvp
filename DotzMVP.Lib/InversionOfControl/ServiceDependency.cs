using DotzMVP.Lib.Services.CustomerService;
using DotzMVP.Lib.Services.UserService;
using Microsoft.Extensions.DependencyInjection;

namespace DotzMVP.Lib.InversionOfControl
{
    public static class ServiceDependency
    {
        public static void AddServiceDependency(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICustomerService, CustomerService>();
        }
    }
}
