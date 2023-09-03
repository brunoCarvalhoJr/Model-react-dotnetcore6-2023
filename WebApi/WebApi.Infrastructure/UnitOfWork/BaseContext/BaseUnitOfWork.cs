using WebApi_Infrastructure.Models;
using WebApi_Infrastructure.Repositories.UserContext.Interfaces;
using WebApi_Infrastructure.UnitOfWork.BaseContext.Interfaces;
using WebApi_Infrastructure.UnitOfWork.ConfigContext;

namespace WebApi_Infrastructure.UnitOfWork.BaseContext
{
    public class BaseUnitOfWork : BaseConfigUnitOfWork, IBaseUnitOfWork
    {
        public BaseUnitOfWork(ApplicationDbContext applicationDbContext, IUserRepository userRepository) : base(applicationDbContext)
        {
            UserRepository = userRepository;
        }

        public IUserRepository UserRepository { get; }
    }
}
