using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi_Crosscuting.Dto.ProfileContext
{
    public class ProfileScreenAddDto
    {
        public string ScreenName { get; set; }
        public IEnumerable<string> Routes { get; set; }
    }
}
