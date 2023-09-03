using WebApi_Infrastructure.Repositories.UserContext.Interfaces;
using WebApi_Infrastructure.UnitOfWork.ConfigContext.Interfaces;

namespace WebApi_Infrastructure.UnitOfWork.BaseContext.Interfaces
{
    public interface IBaseUnitOfWork : IBaseConfigUnitOfWork
    {
        IUserRepository UserRepository { get; }
    }
}
