using WebApi_Domain.Entities.User;
using System.Threading.Tasks;

namespace WebApi_Service.ApplicationService.Modules.ConfigContext.Interfaces
{
    public interface IBaseApplicationService
    {
        Task<UserEntity> GetLoggedUserUntracked();
        Task<UserEntity> GetLoggedUserTracked();
    }
}
