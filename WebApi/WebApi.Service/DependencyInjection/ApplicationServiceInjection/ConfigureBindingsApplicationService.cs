using WebApi_Service.ApplicationService.Modules.AuthContext;
using WebApi_Service.ApplicationService.Modules.AuthContext.Interfaces;
using WebApi_Service.ApplicationService.Modules.ConfigContext;
using WebApi_Service.ApplicationService.Modules.ConfigContext.Interfaces;
using WebApi_Service.ApplicationService.Modules.ProfileContext;
using WebApi_Service.ApplicationService.Modules.ProfileContext.Interfaces;
using WebApi_Service.ApplicationService.Modules.User;
using WebApi_Service.ApplicationService.Modules.UserContext.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi_Service.DependencyInjection.ApplicationServiceInjection
{
    public static class ConfigureBindingsApplicationService
    {
        public static void RegisterBindings(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ITokenApplicationService, TokenApplicationService>();
            services.AddScoped<IBaseApplicationService, BaseApplicationService>();
            services.AddScoped<IProfileAppService, ProfileAppService>();


            #region AUTH
            services.AddScoped<IAuthApplicationService, AuthApplicationService>();
            #endregion

            #region USER
            services.AddScoped<IUserAppService, UserAppService>();
            #endregion

        }
    }
}
