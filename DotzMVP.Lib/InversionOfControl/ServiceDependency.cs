using DotzMVP.Lib.Services.ChangeService;
using DotzMVP.Lib.Services.CustomerService;
using DotzMVP.Lib.Services.ProductService;
using DotzMVP.Lib.Services.ScoreService;
using DotzMVP.Lib.Services.UserAdminService;
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
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IScoreService, ScoreService>();
            services.AddScoped<IChangeService, ChangeService>();
            services.AddScoped<IUserAdminService, UserAdminService>();
        }
    }
}
