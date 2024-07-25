using Core.Config;
using Core.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class TokenService : ITokenService, ISingleton
    {
        private IOptions<Security> options;

        public TokenService(IOptions<Security> options)
        { 
            this.options = options;
        }

        public string CreateToken()
        {
            var handler = new JwtSecurityTokenHandler();
            var sharedKey = Encoding.UTF8.GetBytes(options.Value.SharedSecret);
            var key = new SymmetricSecurityKey(sharedKey);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new[] { new Claim("user_id", "1") }),
                Expires = DateTime.UtcNow.AddMinutes(options.Value.ExpireTimeMinutes),
                Issuer = options.Value.Issuer,
                Audience = options.Value.Audiance,
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature)
            };

            var token = handler.CreateToken(tokenDescriptor);

            return handler.WriteToken(token);
        }
    }
}
