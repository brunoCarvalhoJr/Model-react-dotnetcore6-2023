using WebApi_Crosscuting.Dto.UserContext;
using System.Threading;
using System.Threading.Tasks;

namespace WebApi_Service.ApplicationService.Modules.AuthContext.Interfaces
{
    public interface IAuthApplicationService
    {
        Task<LoginResponseDto> Login(LoginDto dto, CancellationToken ctToken);
        Task Register(RegisterDto dto, CancellationToken ctToken);
    }
}
