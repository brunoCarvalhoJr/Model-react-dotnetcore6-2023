using WebApi_Crosscuting.Dto.UserContext;
using WebApi_Infrastructure.UnitOfWork.BaseContext.Interfaces;
using WebApi_Infrastructure.UnitOfWork.UserContext.Interfaces;
using WebApi_Service.ApplicationService.Modules.ConfigContext;
using WebApi_Service.ApplicationService.Modules.UserContext.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebApi_Service.ApplicationService.Modules.User
{
    internal class UserAppService : BaseApplicationService, IUserAppService
    {
        private readonly IAuthUnitOfWork _uow;
        public UserAppService(IBaseUnitOfWork unitOfWork, IAuthUnitOfWork uow) : base(unitOfWork)
        {
            _uow = uow;
        }

        public async Task<IEnumerable<GetAllUsersDto>> GetAllUsers(CancellationToken ct)
        {
            var users = await _uow.UserRepository.GetAllReadOnly().Select(x => new GetAllUsersDto
            {
                Id = x.Id,
                Nome = x.Name
            }).ToListAsync();

            return users;
        }
    }
}
