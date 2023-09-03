using WebApi_Domain.Relationships;
using WebApi_Infrastructure.Models;
using WebApi_Infrastructure.Repositories.ConfigContext;
using WebApi_Infrastructure.Repositories.ProfileContext.Interfaces;

namespace WebApi_Infrastructure.Repositories.ProfileContext
{
    public class UserProfileRepository : GenericRepository<UserProfile>, IUserProfileRepository
    {
        public UserProfileRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
    }
}
 