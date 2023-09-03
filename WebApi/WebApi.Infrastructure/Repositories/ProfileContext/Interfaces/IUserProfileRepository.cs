using WebApi_Domain.Entities.User;
using WebApi_Domain.Relationships;
using WebApi_Infrastructure.Repositories.ConfigContext.Interfaces;

namespace WebApi_Infrastructure.Repositories.ProfileContext.Interfaces
{
    public interface IUserProfileRepository : IGenericRepository<UserProfile>
    {
    }
}
