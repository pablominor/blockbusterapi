using BlockbusterApp.src.Shared.Infraestructure.Security.Authentication.JWT;
using System.Collections.Generic;

namespace BlockbusterApp.src.Domain.TokenAggregate.Service
{
    public class TokenUpdaterService
    {
        private IJWTEncoder JWTEnconder;

        public TokenUpdaterService(IJWTEncoder JWTEnconder)
        {
            this.JWTEnconder = JWTEnconder;
        }

        public Token UpdateTokenHash(Token token, Dictionary<string,string> payload)
        {
            string hash = this.JWTEnconder.Encode(payload);
            TokenHash tokenHash = new TokenHash(hash);
            token.UpdateHash(tokenHash);
            return token;
        }

    }
}
