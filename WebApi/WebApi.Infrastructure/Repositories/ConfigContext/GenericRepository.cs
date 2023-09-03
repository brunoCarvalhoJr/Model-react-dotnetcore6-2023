using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebApi_Infrastructure.Models;
using WebApi_Infrastructure.Repositories.ConfigContext.Interfaces;

namespace WebApi_Infrastructure.Repositories.ConfigContext
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public GenericRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task AddAsync(T obj)
        {
            await _applicationDbContext.Set<T>().AddAsync(obj);
        }

        public void Delete(T obj)
        {
            _applicationDbContext.Set<T>().Remove(obj);
        }

        public void Edit(T obj)
        {
            _applicationDbContext.Set<T>().Update(obj);
        }

        public virtual IQueryable<T> GetAll()
        {
            return _applicationDbContext.Set<T>();
        }

        public virtual IQueryable<T> GetAllReadOnly()
        {
            return _applicationDbContext.Set<T>().AsNoTracking();
        }
    }
}
