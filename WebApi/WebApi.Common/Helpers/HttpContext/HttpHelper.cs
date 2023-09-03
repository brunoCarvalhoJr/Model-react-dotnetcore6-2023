using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi_Common.Configurations.Http;

namespace WebApi_Common.Helpers.HttpContext
{
    public static class HttpHelper
    {
        public static string LoggedUser
        {
            get { return HttpContextGetter.ContextAcessor.HttpContext?.User.Identity.Name; }
        }
    }
}
