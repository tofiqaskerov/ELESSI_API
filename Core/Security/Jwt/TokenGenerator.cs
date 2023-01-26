using Core.Entities.Concrete;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace Core.Security.Jwt
{
    public static class TokenGenerator
    {
        public static string Token(User user, string role)
        {
            var jwtHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes("aersrtbasA5DasdSEwdwedwEWD332WERLG46R2fervsmzutt6601dscTKKKZK14kefkr23");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                 {
                     new Claim(JwtRegisteredClaimNames.NameId, user.Id.ToString()),
                     new Claim(JwtRegisteredClaimNames.Email, user.Email),
                     new Claim (JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                     new Claim (ClaimTypes.Role, role),
                 }),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature),
                Issuer = "Askerov10",
                Audience = "Askerov10"
            };

            var token = jwtHandler.CreateToken(tokenDescriptor);
            return jwtHandler.WriteToken(token);

        }
    }
}
