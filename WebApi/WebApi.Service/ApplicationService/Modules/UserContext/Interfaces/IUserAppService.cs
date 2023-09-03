using WebApi_Crosscuting.Dto.UserContext;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace WebApi_Service.ApplicationService.Modules.UserContext.Interfaces
{
    public interface IUserAppService
    {
        Task<IEnumerable<GetAllUsersDto>> GetAllUsers(CancellationToken ct);
    }
}
