using Application.Abstraction.Authentication;
using Domain.Users;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SQLServer.Authentication
{
    internal sealed class JWTProvider : IJWTProvider
    {
        private readonly JWTOption _jwtOption;

        public JWTProvider(IOptions<JWTOption> jwtOption)
        {
            _jwtOption = jwtOption.Value;
        }


        public string GenerateToken(User user)
        {
            var authClaims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Name, user.Name),
                new Claim(JwtRegisteredClaimNames.Email, user.Email!),
                new Claim(JwtRegisteredClaimNames.Sub, user.Id)
            };

            var signingCredencials = new SigningCredentials
            (
                new SymmetricSecurityKey
                (
                    Encoding.UTF8.GetBytes(_jwtOption.SecretKey)
                ),
                SecurityAlgorithms.HmacSha256Signature
            );

            var token = new JwtSecurityToken
            (
                _jwtOption.Issuer,
                _jwtOption.Audience,
                authClaims,
                null,
                DateTime.UtcNow.AddHours(1),
                signingCredencials
            );

            string tokenValue = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenValue;
        }
    }
}
