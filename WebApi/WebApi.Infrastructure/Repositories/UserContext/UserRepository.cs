using WebApi_Domain.Entities.User;
using WebApi_Infrastructure.Models;
using WebApi_Infrastructure.Repositories.ConfigContext;
using WebApi_Infrastructure.Repositories.UserContext.Interfaces;

namespace WebApi_Infrastructure.Repositories.UserContext
{
    public class UserRepository : GenericRepository<UserEntity>, IUserRepository
    {
        public UserRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
    }
}
