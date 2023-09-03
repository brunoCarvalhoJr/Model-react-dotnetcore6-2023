using WebApi_Domain.Entities.User;
using WebApi_Infrastructure.Repositories.ConfigContext.Interfaces;

namespace WebApi_Infrastructure.Repositories.UserContext.Interfaces
{
    public interface IUserRepository : IGenericRepository<UserEntity>
    {
    }
}
