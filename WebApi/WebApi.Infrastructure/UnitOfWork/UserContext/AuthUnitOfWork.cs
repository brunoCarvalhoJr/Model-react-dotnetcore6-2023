using WebApi_Infrastructure.Models;
using WebApi_Infrastructure.Repositories.AuditContext.Interfaces;
using WebApi_Infrastructure.Repositories.UserContext.Interfaces;
using WebApi_Infrastructure.UnitOfWork.ConfigContext;
using WebApi_Infrastructure.UnitOfWork.UserContext.Interfaces;

namespace WebApi_Infrastructure.UnitOfWork.UserContext
{
    public class AuthUnitOfWork : BaseConfigUnitOfWork, IAuthUnitOfWork
    {
        public AuthUnitOfWork(ApplicationDbContext applicationDbContext, IUserRepository userRepository, ILogRepository logRepository) : base(applicationDbContext)
        {
            UserRepository = userRepository;
            LogRepository = logRepository;
        }

        public IUserRepository UserRepository { get; }

        public ILogRepository LogRepository { get; }


    }
}
