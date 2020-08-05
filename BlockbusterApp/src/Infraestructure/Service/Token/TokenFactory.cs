using BlockbusterApp.src.Domain.TokenAggregate;
using BlockbusterApp.src.Shared.Infraestructure.Security.Authentication.JWT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Infraestructure.Service.Token
{
    public class TokenFactory : ITokenFactory
    {
        private IJWTEncoder JWTEnconder;
        public TokenFactory(IJWTEncoder JWTEnconder)
        {
            this.JWTEnconder = JWTEnconder;
        }

        public Domain.TokenAggregate.Token Create(Dictionary<string, string> payload)
        {
            string hash = this.JWTEnconder.Encode(payload);
            TokenHash tokenHash = new TokenHash(hash);
            TokenUserId tokenUserId = new TokenUserId(payload[TokenClaimTypes.USER_ID]);

            return Domain.TokenAggregate.Token.Create(tokenHash, tokenUserId);
        }
    }
}
