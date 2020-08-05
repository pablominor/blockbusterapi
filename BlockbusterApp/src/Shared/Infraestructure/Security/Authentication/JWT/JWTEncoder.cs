using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Shared.Infraestructure.Security.Authentication.JWT
{
    public class JWTEncoder : IJWTEncoder
    {
        private IConfiguration configuration;

        public JWTEncoder(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string Encode(Dictionary<string, string> payload)
        {
            var secret = this.configuration.GetValue<string>("AppSettings:Secret");

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(TokenClaimTypes.USER_ID, payload[TokenClaimTypes.USER_ID]),
                    new Claim(TokenClaimTypes.EMAIL, payload[TokenClaimTypes.EMAIL]),
                    new Claim(TokenClaimTypes.FIRST_NAME, payload[TokenClaimTypes.FIRST_NAME]),
                    new Claim(TokenClaimTypes.LAST_NAME, payload[TokenClaimTypes.LAST_NAME]),
                    new Claim(TokenClaimTypes.ROLE, payload[TokenClaimTypes.ROLE])
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }   
    }
}
