using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TechTrial.JWT;

namespace TechTrial.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        ///// <summary>
        ///// Metodo que genera un token de autenticacion JWT con los claims proporcionados
        ///// </summary>
        ///// <returns>string con el  </returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetToken()
        {
            //// Aqui se les proporciona los claims que se desean agregar al token
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, "Esmerlin Borges C."),
                new Claim(ClaimTypes.Email, "esmerlinborges@outlook.com"),
            };

            return Ok(_authService.GenerateAccessToken(claims));
        }
    }
}
