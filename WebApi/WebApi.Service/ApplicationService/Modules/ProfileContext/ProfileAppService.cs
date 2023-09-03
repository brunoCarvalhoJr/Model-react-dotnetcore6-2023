using WebApi_Crosscuting.Dto.ProfileContext;
using WebApi_Domain.Entities.User;
using WebApi_Domain.Relationships;
using WebApi_Infrastructure.UnitOfWork.BaseContext.Interfaces;
using WebApi_Infrastructure.UnitOfWork.ProfileContext.Interfaces;
using WebApi_Service.ApplicationService.Modules.ConfigContext;
using WebApi_Service.ApplicationService.Modules.ProfileContext.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebApi_Service.ApplicationService.Modules.ProfileContext
{
    public class ProfileAppService : BaseApplicationService, IProfileAppService
    {
        private readonly IProfileUnitOfWork _uow;
        public ProfileAppService(IBaseUnitOfWork unitOfWork, IProfileUnitOfWork uow) : base(unitOfWork)
        {
            _uow = uow;
        }

        public async Task CreateNewProfile(ProfileScreenAddDto dto, CancellationToken ct = default)
        {
            var profile = new ScreenProfile
            {
                ScreenName = dto.ScreenName,
                Routes = dto.Routes.Select(x => new ScreenRoutes
                {
                    Route = x,
                }).ToList()
            };

            await _uow.ProfileRepository.AddAsync(profile);
            await _uow.CommitAsync();

        }

        public async Task ProfileAssociation(ProfileAssociationDto dto, CancellationToken ct = default)
        {
            var UserProfile = new UserProfile
            {
                ProfileId = dto.ProfileID,
                UserId = dto.UserID
            };

            await _uow.UserProfileRepository.AddAsync(UserProfile);
            await _uow.CommitAsync();
        }
    }
}
