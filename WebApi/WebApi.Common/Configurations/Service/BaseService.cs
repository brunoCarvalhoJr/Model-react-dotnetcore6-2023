using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi_Common.Helpers.HttpContext;

namespace WebApi_Common.Configurations.Service
{
    public abstract class BaseService
    {
        protected string LoggedUser
        {
            get { return HttpHelper.LoggedUser; }
        }
    }
}
