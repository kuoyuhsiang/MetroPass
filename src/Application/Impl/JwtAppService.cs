using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MetroPass.Application.Configurations;
using MetroPass.Application.Interface;
using Microsoft.IdentityModel.Tokens;

namespace MetroPass.Application.Impl
{
    public class JwtAppService : IJwtService
    {
        private readonly JwtConfig _jwtConfig;

        public JwtAppService(JwtConfig jwtConfig)
        {
            _jwtConfig = jwtConfig;
        }

        public string GenerateToken(string account)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, account)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfig.Key!));
            var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: _jwtConfig.Issuer,
                audience: _jwtConfig.Audience,
                claims: claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: credential
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}