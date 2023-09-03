using WebApi_Domain.Entities.User;
using WebApi_Infrastructure.Repositories.ConfigContext.Interfaces;

namespace WebApi_Infrastructure.Repositories.ProfileContext.Interfaces
{
    public interface IProfileRepository: IGenericRepository<ScreenProfile>
    {
    }
}
