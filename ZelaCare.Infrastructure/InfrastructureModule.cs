using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ZelaCare.Core.Repositories;
using ZelaCare.Infrastructure.Persistence;
using ZelaCare.Infrastructure.Persistence.Repositories;

namespace ZelaCare.Infrastructure
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ZelaCareDbContext>(options =>
            options.UseInMemoryDatabase(connectionString));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IClinicRepository, ClinicRepository>();
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IProfessionalRepository, ProfessionalRepository>();

            return services;
        }
    }
}
