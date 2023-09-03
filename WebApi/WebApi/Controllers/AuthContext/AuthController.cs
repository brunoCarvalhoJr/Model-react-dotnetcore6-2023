using WebApi_Crosscuting.Dto.UserContext;
using WebApi_Service.ApplicationService.Modules.AuthContext.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace WebApi_Interface.Controllers.Auth
{
    [ApiController]
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        private readonly IAuthApplicationService _authApplicationService;

        public AuthController(IAuthApplicationService authApplicationService)
        {
            _authApplicationService = authApplicationService;
        }

        /// <summary>
        /// Rota para realização de login
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="ctToken"></param>
        /// <returns></returns>
        [SwaggerResponse(statusCode: 200, description: "Login Success", Type = typeof(LoginResponseDto))]
        [SwaggerResponse(statusCode: 400, description: "Internal Server Error", Type = typeof(string))]
        [SwaggerResponse(statusCode: 409, description: "Conflict", Type = typeof(string))]
        [SwaggerResponse(statusCode: 404, description: "User not found", Type = typeof(string))]
        [Produces("application/json")]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto, CancellationToken ctToken)
        {
            CookieOptions cookieOptions = new();
            cookieOptions.HttpOnly = true;
            var resp = await _authApplicationService.Login(dto, ctToken);
            Response.Cookies.Append("refresh_token", resp.Token, cookieOptions);
            return Ok(resp);
        }


        [SwaggerResponse(statusCode: 200, description: "Register Success")]
        [SwaggerResponse(statusCode: 400, description: "Internal Server Error", Type = typeof(string))]
        [SwaggerResponse(statusCode: 409, description: "Conflict", Type = typeof(string))]
        [Produces("application/json")]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto dto, CancellationToken ctToken)
        {
            await _authApplicationService.Register(dto, ctToken);
            return Ok();
        }

    }
}
