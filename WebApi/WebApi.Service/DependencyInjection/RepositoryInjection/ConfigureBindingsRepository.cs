using WebApi_Infrastructure.Repositories.AuditContext;
using WebApi_Infrastructure.Repositories.AuditContext.Interfaces;
using WebApi_Infrastructure.Repositories.ProfileContext;
using WebApi_Infrastructure.Repositories.ProfileContext.Interfaces;
using WebApi_Infrastructure.Repositories.UserContext;
using WebApi_Infrastructure.Repositories.UserContext.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi_Service.DependencyInjection.RepositoryInjection
{
    public static class ConfigureBindingsRepository
    {
        public static void RegisterBindings(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ILogRepository, LogRepository>();
            services.AddScoped<IProfileRepository, ProfileRepository>();
            services.AddScoped<IUserProfileRepository, UserProfileRepository>();
        }

    }
}
