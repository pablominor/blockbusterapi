using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Application.UseCase.Token.Create
{
    public class TokenConverter
    {
        public TokenConverter() { }

        public virtual IResponse Convert(Domain.TokenAggregate.Token token)
        {
            return new CreateTokenResponse()
            {
                Hash = token.hash.GetValue()
            };
               
        }
    }
}
