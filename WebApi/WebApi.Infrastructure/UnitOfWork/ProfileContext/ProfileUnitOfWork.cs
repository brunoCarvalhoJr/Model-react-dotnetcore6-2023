using WebApi_Infrastructure.Models;
using WebApi_Infrastructure.Repositories.ProfileContext.Interfaces;
using WebApi_Infrastructure.Repositories.UserContext.Interfaces;
using WebApi_Infrastructure.UnitOfWork.ConfigContext;
using WebApi_Infrastructure.UnitOfWork.ProfileContext.Interfaces;

namespace WebApi_Infrastructure.UnitOfWork.ProfileContext
{
    public class ProfileUnitOfWork : BaseConfigUnitOfWork, IProfileUnitOfWork
    {
        public ProfileUnitOfWork(ApplicationDbContext applicationDbContext, IUserRepository userRepository, IProfileRepository logRepository, IUserProfileRepository userProfile) : base(applicationDbContext)
        {
            UserRepository = userRepository;
            ProfileRepository = logRepository;
            UserProfileRepository = userProfile;
        }

        public IUserRepository UserRepository { get; }

        public IProfileRepository ProfileRepository { get; }
        public IUserProfileRepository UserProfileRepository { get; }
    }
}
