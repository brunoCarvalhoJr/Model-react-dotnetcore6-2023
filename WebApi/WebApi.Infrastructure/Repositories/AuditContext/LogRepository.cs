using WebApi_Domain.Entities.Audit;
using WebApi_Infrastructure.Models;
using WebApi_Infrastructure.Repositories.AuditContext.Interfaces;
using WebApi_Infrastructure.Repositories.ConfigContext;

namespace WebApi_Infrastructure.Repositories.AuditContext
{
    public class LogRepository : GenericRepository<LogEntity>, ILogRepository
    {
        public LogRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
    }
}
