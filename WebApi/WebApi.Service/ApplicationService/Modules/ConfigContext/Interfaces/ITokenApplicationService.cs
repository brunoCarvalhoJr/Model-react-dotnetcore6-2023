using WebApi_Domain.Entities.User;

namespace WebApi_Service.ApplicationService.Modules.ConfigContext.Interfaces
{
    public interface ITokenApplicationService
    {
        string GenerateToken(UserEntity user);
    }
}
