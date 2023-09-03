using WebApi_Common.Exceptions;
using WebApi_Common.Helpers.HttpContext;
using WebApi_Domain.Entities.User;
using WebApi_Infrastructure.UnitOfWork.BaseContext.Interfaces;
using WebApi_Service.ApplicationService.Modules.ConfigContext.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi_Service.ApplicationService.Modules.ConfigContext
{
    public class BaseApplicationService : IBaseApplicationService
    {
        protected readonly IBaseUnitOfWork BaseUnitOfWork;

        public BaseApplicationService(IBaseUnitOfWork unitOfWork)
        {
            BaseUnitOfWork = unitOfWork;
        }

        public async Task<UserEntity> GetLoggedUserTracked()
        {
            var loggedUserName = HttpHelper.LoggedUser;
            var user = await BaseUnitOfWork.UserRepository.GetAll().Where(x => x.Email == loggedUserName).FirstOrDefaultAsync();

            if (user == null)
            {
                throw new DomainException("User not found");
            }

            return user;
        }

        public IQueryable<UserEntity> GetLoggedUserTrackedQuery()
        {
            var loggedUserName = HttpHelper.LoggedUser;
            var user = BaseUnitOfWork.UserRepository.GetAll().Where(x => x.Email == loggedUserName);

            if (user == null)
            {
                throw new DomainException("User not found");
            }

            return user;
        }


        public async Task<UserEntity> GetLoggedUserUntracked()
        {
            var loggedUserName = HttpHelper.LoggedUser;
            var user = await BaseUnitOfWork.UserRepository.GetAll().Where(x => x.Email == loggedUserName).FirstOrDefaultAsync();

            if (user == null)
            {
                throw new DomainException("User not found");
            }

            return user;
        }


    }
}
