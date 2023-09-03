using WebApi_Service.DependencyInjection.ApplicationServiceInjection;
using WebApi_Service.DependencyInjection.RepositoryInjection;
using WebApi_Service.DependencyInjection.UnitOfWorkInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi_Service.DependencyInjection
{
    public static class ConfigureBindingsDependencyInjection
    {

        public static void RegisterBindings(IServiceCollection services, IConfiguration configuration)
        {
            ConfigureBindingsApplicationService.RegisterBindings(services, configuration);
            ConfigureBindingsRepository.RegisterBindings(services, configuration);
            ConfigureBindinsUnifOfWorks.RegisterBindings(services, configuration);
        }
    }
}