using WebApi_Crosscuting.Dto.ProfileContext;
using WebApi_Crosscuting.Dto.UserContext;
using WebApi_Service.ApplicationService.Modules.ProfileContext.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace WebApi_Interface.Controllers.Profile
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileAppService _appService;

        public ProfileController(IProfileAppService appService)
        {
            _appService = appService;
        }


        /// <summary>
        /// Adiciona um novo perfil de acesso
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="ctToken"></param>
        /// <returns></returns>
        [SwaggerResponse(statusCode: 200, description: "Created")]
        [SwaggerResponse(statusCode: 400, description: "Internal Server Error", Type = typeof(string))]
        [SwaggerResponse(statusCode: 409, description: "Conflict", Type = typeof(string))]
        //[SwaggerResponse(statusCode: 404, description: "User not found", Type = typeof(string))]
        [Produces("application/json")]
        [HttpPost("addnewprofile")]
        public async Task<IActionResult> GetSchoolsUserAsAdmin(CancellationToken ctToken, [FromBody] ProfileScreenAddDto dto)
        {
            await _appService.CreateNewProfile(dto, ctToken);
            return Ok();
        }


        /// <summary>
        /// Associa um usuario a um perfil
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="ctToken"></param>
        /// <returns></returns>
        [SwaggerResponse(statusCode: 200, description: "Created")]
        [SwaggerResponse(statusCode: 400, description: "Internal Server Error", Type = typeof(string))]
        [SwaggerResponse(statusCode: 409, description: "Conflict", Type = typeof(string))]
        //[SwaggerResponse(statusCode: 404, description: "User not found", Type = typeof(string))]
        [Produces("application/json")]
        [HttpPost("associate")]
        public async Task<IActionResult> Associate(CancellationToken ctToken, [FromBody] ProfileAssociationDto dto)
        {
            await _appService.ProfileAssociation(dto, ctToken);
            return Ok();
        }

        /// <summary>
        /// Associa um usuario a um perfil
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="ctToken"></param>
        /// <returns></returns>
        [SwaggerResponse(statusCode: 200, description: "Created")]
        [SwaggerResponse(statusCode: 400, description: "Internal Server Error", Type = typeof(string))]
        [SwaggerResponse(statusCode: 409, description: "Conflict", Type = typeof(string))]
        //[SwaggerResponse(statusCode: 404, description: "User not found", Type = typeof(string))]
        [Produces("application/json")]
        [HttpGet("teste6")]
        [Authorize(Roles = "teste6")]
        public async Task<IActionResult> Teste(CancellationToken ctToken) => Ok("teste");

        /// <summary>
        /// Associa um usuario a um perfil
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="ctToken"></param>
        /// <returns></returns>
        [SwaggerResponse(statusCode: 200, description: "Created")]
        [SwaggerResponse(statusCode: 400, description: "Internal Server Error", Type = typeof(string))]
        [SwaggerResponse(statusCode: 409, description: "Conflict", Type = typeof(string))]
        //[SwaggerResponse(statusCode: 404, description: "User not found", Type = typeof(string))]
        [Produces("application/json")]
        [HttpGet("teste7")]
        [Authorize(Roles = "teste7")]
        public async Task<IActionResult> Teste2(CancellationToken ctToken) => Ok("teste2");
    }
}
