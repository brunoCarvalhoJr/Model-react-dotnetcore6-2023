using WebApi_Infrastructure.UnitOfWork.BaseContext;
using WebApi_Infrastructure.UnitOfWork.BaseContext.Interfaces;
using WebApi_Infrastructure.UnitOfWork.ConfigContext;
using WebApi_Infrastructure.UnitOfWork.ConfigContext.Interfaces;
using WebApi_Infrastructure.UnitOfWork.ProfileContext;
using WebApi_Infrastructure.UnitOfWork.ProfileContext.Interfaces;
using WebApi_Infrastructure.UnitOfWork.UserContext;
using WebApi_Infrastructure.UnitOfWork.UserContext.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi_Service.DependencyInjection.UnitOfWorkInjection
{
    public static class ConfigureBindinsUnifOfWorks
    {
        public static void RegisterBindings(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IAuthUnitOfWork, AuthUnitOfWork>();
            services.AddScoped<IBaseConfigUnitOfWork, BaseConfigUnitOfWork>();
            services.AddScoped<IBaseUnitOfWork, BaseUnitOfWork>();
            services.AddScoped<IProfileUnitOfWork, ProfileUnitOfWork>();
        }
    }
}
