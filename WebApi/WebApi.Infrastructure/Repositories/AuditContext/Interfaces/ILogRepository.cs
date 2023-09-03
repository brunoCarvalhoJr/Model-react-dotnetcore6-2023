using WebApi_Domain.Entities.Audit;
using WebApi_Infrastructure.Repositories.ConfigContext.Interfaces;

namespace WebApi_Infrastructure.Repositories.AuditContext.Interfaces
{
    public interface ILogRepository : IGenericRepository<LogEntity>
    {
    }
}
