using WebApi_Common.Exceptions;
using WebApi_Common.Helpers.AuditContext;
using WebApi_Common.Helpers.ConvertContext;
using WebApi_Common.Helpers.ValidatorContext;
using WebApi_Crosscuting.Dto.UserContext;
using WebApi_Domain.Entities.User;
using WebApi_Infrastructure.UnitOfWork.UserContext.Interfaces;
using WebApi_Service.ApplicationService.Modules.AuthContext.Interfaces;
using WebApi_Service.ApplicationService.Modules.ConfigContext.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace WebApi_Service.ApplicationService.Modules.AuthContext
{
    public class AuthApplicationService : IAuthApplicationService
    {
        private readonly IAuthUnitOfWork _uow;
        private readonly ITokenApplicationService tokenApplicationService;

        public AuthApplicationService(IAuthUnitOfWork uow, ITokenApplicationService tokenApplicationService)
        {
            _uow = uow;
            this.tokenApplicationService = tokenApplicationService;
        }

        public async Task<LoginResponseDto> Login(LoginDto dto, CancellationToken ctToken = default)
        {
            ctToken.ThrowIfCancellationRequested();

            var password = dto.Password.ToSha256();
            var user = await _uow.UserRepository.GetAllReadOnly()
                                                .Include(x => x.EntityTypes)
                                                .Include(x => x.UserProfile)
                                                .ThenInclude(x => x.Profile)
                                                .ThenInclude(x => x.Routes)
                                                .Where(user => user.Email == dto.Email && user.Password == password)
                                                .FirstOrDefaultAsync(ctToken);

            if (user == null)
            {
                await _uow.LogRepository.AddAsync(AuditHelper.LogEntityWrongPassword(dto.Email));
                await _uow.CommitAsync();

                user.Invalid("Email or Password");
            }

            var userLogged = new LoginResponseDto
            {
                Token = tokenApplicationService.GenerateToken(user),
                AuthorizedRoutes = user.UserProfile.Select(x => x.Profile.ScreenName).ToList(),
                UserType = user.EntityTypes.Select(x => new LoginUserTypeDto
                {
                    Type = x.Type,
                    TypeName = x.Name
                })
            };

            await _uow.LogRepository.AddAsync(AuditHelper.LogEntityLogin(user));
            await _uow.CommitAsync();

            return userLogged;
        }

        public async Task Register(RegisterDto dto, CancellationToken ctToken = default)
        {
            ctToken.ThrowIfCancellationRequested();

            var emailAlreadyRegisted = _uow.UserRepository.GetAllReadOnly().Any(user => user.Email == dto.Email);

            if (emailAlreadyRegisted)
            {
                throw new DomainException("User already registered.");
            }

            var newUser = new UserEntity
            {
                Email = dto.Email,
                Name = dto.Name,
                Password = dto.Password.ToSha256(),
                LastName = dto.LastName,
                EntityTypes = new List<EntityTypesEntity>
                    {
                        new EntityTypesEntity
                        {
                            Type = 1,
                            Name = "Administrator"
                        }
                    }
            };

            await _uow.UserRepository.AddAsync(newUser);
            await _uow.LogRepository.AddAsync(AuditHelper.LogEntityRegister(newUser));

            await _uow.CommitAsync();
        }

    }
}
