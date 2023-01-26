using Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System.IdentityModel.Tokens.Jwt;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Elessi_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userManager;

        public UserController(IUserService userManager)
        {
            _userManager = userManager;
        }


        [Authorize]
        [HttpGet("getByEmail")]
        public async Task<IActionResult> GetByEmail()
        {
            var _bearer_token = Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");

            var handler = new JwtSecurityTokenHandler();

            var jwtSecurityToken = handler.ReadJwtToken(_bearer_token);

            var email = jwtSecurityToken.Claims.FirstOrDefault(x => x.Type == "email").Value;

            var result = _userManager.GetUserByEmail(email);

            if (result.Success) return Ok(new { status = 200, data = result.Data });

            return BadRequest(new { status = 401, message = result.Message });
        }

       
    }
}
