using WebApi_Domain.Entities.User;
using WebApi_Service.ApplicationService.Modules.ConfigContext.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace WebApi_Service.ApplicationService.Modules.ConfigContext
{
    public class TokenApplicationService : ITokenApplicationService
    {
        private readonly IConfiguration _configuration;
        private readonly string _key;

        public TokenApplicationService(IConfiguration configuration)
        {
            _configuration = configuration;
            _key = configuration.GetSection("JwtConfiguration:Secret").Value;
        }

        public string GenerateToken(UserEntity user)
        {
            var allProfiles = user.UserProfile.Select(x => x.Profile.Routes.Select(x => x.Route).ToList()).ToList();
            var allRolesFromUser = allProfiles.SelectMany(x => x).ToList();

            var claims = new List<Claim> {
                                new Claim(ClaimTypes.NameIdentifier, user.Email.ToString()),
                                new Claim(ClaimTypes.Name, user.Email.ToString()),
                            };

            foreach (var profile in allRolesFromUser)
            {
                claims.Add(new Claim(ClaimTypes.Role, profile));
            }

            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_key);

            var tokenDescriptor =
                new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims.ToArray()),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                    Expires = DateTime.UtcNow.AddHours(24)
                };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

    }
}
