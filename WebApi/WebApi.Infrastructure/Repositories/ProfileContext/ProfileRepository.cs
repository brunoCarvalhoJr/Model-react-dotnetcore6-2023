using WebApi_Domain.Entities.User;
using WebApi_Infrastructure.Models;
using WebApi_Infrastructure.Repositories.ConfigContext;
using WebApi_Infrastructure.Repositories.ProfileContext.Interfaces;

namespace WebApi_Infrastructure.Repositories.ProfileContext
{
    public class ProfileRepository : GenericRepository<ScreenProfile>, IProfileRepository
    {
        public ProfileRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
    }
}
