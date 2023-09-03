using WebApi_Crosscuting.Dto.UserContext;
using WebApi_Service.ApplicationService.Modules.UserContext.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace WebApi_Interface.Controllers.User
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserAppService _appService;

        public UserController(IUserAppService appService)
        {
            _appService = appService;
        }


        /// <summary>
        /// Rota para Obter todas escolas que o usuario administra
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="ctToken"></param>
        /// <returns></returns>
        [SwaggerResponse(statusCode: 200, description: "Lista de escolas", Type = typeof(IEnumerable<GetAllUsersDto>))]
        [SwaggerResponse(statusCode: 400, description: "Internal Server Error", Type = typeof(string))]
        [SwaggerResponse(statusCode: 409, description: "Conflict", Type = typeof(string))]
        [SwaggerResponse(statusCode: 404, description: "User not found", Type = typeof(string))]
        [Produces("application/json")]
        [HttpGet("adminlist")]
        public async Task<IActionResult> GetSchoolsUserAsAdmin(CancellationToken ctToken) => Ok(await _appService.GetAllUsers(ctToken));
    }
}
