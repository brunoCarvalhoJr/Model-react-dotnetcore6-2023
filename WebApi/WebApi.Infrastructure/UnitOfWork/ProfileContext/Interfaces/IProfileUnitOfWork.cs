using WebApi_Infrastructure.Repositories.ProfileContext.Interfaces;
using WebApi_Infrastructure.Repositories.UserContext.Interfaces;
using WebApi_Infrastructure.UnitOfWork.ConfigContext.Interfaces;

namespace WebApi_Infrastructure.UnitOfWork.ProfileContext.Interfaces
{
    public interface IProfileUnitOfWork : IBaseConfigUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IProfileRepository ProfileRepository { get; }
        IUserProfileRepository UserProfileRepository { get; }
    }
}
