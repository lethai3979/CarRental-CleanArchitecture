using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SQLServer.Authentication;
using System.Text;

namespace API.OptionSetup
{
    public class JWTBearerOptionSetup : IConfigureOptions<JwtBearerOptions>
    {
        private readonly JWTOption _jwtOption;

        public JWTBearerOptionSetup(JWTOption jwtOption)
        {
            _jwtOption = jwtOption;
        }

        public void Configure(JwtBearerOptions options)
        {
            options.TokenValidationParameters = new()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = _jwtOption.Issuer,
                ValidAudience = _jwtOption.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_jwtOption.SecretKey))
            };
        }
    }
}
