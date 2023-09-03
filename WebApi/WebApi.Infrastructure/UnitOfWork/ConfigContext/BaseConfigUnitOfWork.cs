using WebApi_Infrastructure.Models;
using WebApi_Infrastructure.UnitOfWork.ConfigContext.Interfaces;
using System.Threading.Tasks;

namespace WebApi_Infrastructure.UnitOfWork.ConfigContext
{
    public class BaseConfigUnitOfWork : IBaseConfigUnitOfWork
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public BaseConfigUnitOfWork(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task CommitAsync()
        {
            await _applicationDbContext.SaveChangesAsync();
        }
    }
}
