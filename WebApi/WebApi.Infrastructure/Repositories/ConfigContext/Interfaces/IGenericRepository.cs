using System.Linq;
using System.Threading.Tasks;

namespace WebApi_Infrastructure.Repositories.ConfigContext.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task AddAsync(T obj);
        void Edit(T obj);
        void Delete(T obj);
        IQueryable<T> GetAll();
        IQueryable<T> GetAllReadOnly();
    }
}
