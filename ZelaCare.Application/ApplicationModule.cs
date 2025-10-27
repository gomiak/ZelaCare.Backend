using Microsoft.Extensions.DependencyInjection;
using ZelaCare.Application.Services;

namespace ZelaCare.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IClinicService, ClinicService>();

            return services;
        }
    }
}
