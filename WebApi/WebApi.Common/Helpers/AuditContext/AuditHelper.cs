using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi_Domain.Entities.Audit;
using WebApi_Domain.Entities.User;

namespace WebApi_Common.Helpers.AuditContext
{
    public static class AuditHelper
    {
        public static LogEntity LogEntityRegister(UserEntity user)
        {
            return new LogEntity
            {
                Id = Guid.NewGuid(),
                LogTime = DateTime.Now,
                TypeName = "Register",
                UserName = user.Email,
                Type = 1
            };
        }

        public static LogEntity LogEntityLogin(UserEntity user)
        {
            return new LogEntity
            {
                Id = Guid.NewGuid(),
                LogTime = DateTime.Now,
                TypeName = "Login",
                UserName = user.Email,
                Type = 2
            };
        }

        public static LogEntity LogEntityWrongPassword(string user)
        {
            return new LogEntity
            {
                Id = Guid.NewGuid(),
                LogTime = DateTime.Now,
                TypeName = "Wrong Password",
                UserName = user,
                Type = 3
            };
        }


    }
}
