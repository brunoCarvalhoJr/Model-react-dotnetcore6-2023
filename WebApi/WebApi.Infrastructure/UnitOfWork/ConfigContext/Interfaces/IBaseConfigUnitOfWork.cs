using System.Threading.Tasks;

namespace WebApi_Infrastructure.UnitOfWork.ConfigContext.Interfaces
{
    public interface IBaseConfigUnitOfWork
    {
        Task CommitAsync();
    }
}
