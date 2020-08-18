using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Application.UseCase.Token.Response
{
    public class CreateTokenResponse : Token, IResponse
    {
        public CreateTokenResponse() : base() { }
    }
}
