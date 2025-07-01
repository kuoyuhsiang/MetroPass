using System.Security.Principal;
using MetroPass.Presentation.WebApi.Models.Request;
using MetroPass.Presentation.WebApi.Models.Response;
using Microsoft.AspNetCore.Mvc;

namespace MetroPass.Presentation.WebApi.Controllers
{
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IJwtService _jwtService;

        public AuthController(IJwtService jwtService)
        {
            _jwtService = jwtService;
        }
        
        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            if (request.Account == "Admin" && request.Password == "1234")
            {
                var token = _jwtService.GenerateToken(request.Account);
                return Ok(new LoginResponse { Token = token });
            }

            return Unauthorized("帳號密碼錯誤");
        }
    }
}