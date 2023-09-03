using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi_Common.Configurations.Http
{
    public static class HttpContextGetter
    {
        public static IHttpContextAccessor ContextAcessor;

        public static void Configure(IHttpContextAccessor acessor)
        {
            ContextAcessor = acessor;
        }
    }
}
