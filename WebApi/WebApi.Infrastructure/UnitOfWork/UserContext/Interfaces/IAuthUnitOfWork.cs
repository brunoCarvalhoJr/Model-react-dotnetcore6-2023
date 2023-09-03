using WebApi_Infrastructure.Repositories.AuditContext.Interfaces;
using WebApi_Infrastructure.Repositories.UserContext.Interfaces;
using WebApi_Infrastructure.UnitOfWork.ConfigContext.Interfaces;

namespace WebApi_Infrastructure.UnitOfWork.UserContext.Interfaces
{
    public interface IAuthUnitOfWork : IBaseConfigUnitOfWork
    {
        IUserRepository UserRepository { get; }
        ILogRepository LogRepository { get; }
    }
}
