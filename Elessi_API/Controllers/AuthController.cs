using Business.Abstract;
using Business.Constants.User;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Elessi_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authManager;

        public AuthController(IAuthService authManager)
        {
            _authManager = authManager;
        }

       

        [HttpPost("register")]
        public IActionResult Register(RegisterDTO registerDTO)
        {
            var result = _authManager.Register(registerDTO);
            if (result.Success) return Ok(new { status = 200, message = UserMessage.UserRegistered });
   
            return BadRequest(new { status = 400, message = UserMessage.ErrorOnRegister });
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDTO loginDTO)
        {
            var result = _authManager.Login(loginDTO);
            if (result.Success) return Ok(new { status = 200, token = result.Message, data = result.Data });

            return BadRequest(new { status = 401, message = result.Message });
        }

    }
}
