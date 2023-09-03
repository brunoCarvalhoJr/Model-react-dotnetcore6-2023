using WebApi_Crosscuting.Dto.ProfileContext;
using System.Threading;
using System.Threading.Tasks;

namespace WebApi_Service.ApplicationService.Modules.ProfileContext.Interfaces
{
    public interface IProfileAppService
    {
        Task CreateNewProfile(ProfileScreenAddDto dto, CancellationToken ct = default);
        Task ProfileAssociation(ProfileAssociationDto dto, CancellationToken ct = default);
    }
}
