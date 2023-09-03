using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi_Crosscuting.Dto.UserContext
{
    public class LoginResponseDto
    {
        public string Token { get; set; }
        public IEnumerable<LoginUserTypeDto> UserType { get; set; }
        public IEnumerable<string> AuthorizedRoutes { get; set; }
    }
}
