using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Application.UseCase.Token.Create
{
    public class CreateTokenResponse : IResponse
    {
        public string Hash { get; set; }
    }
}
