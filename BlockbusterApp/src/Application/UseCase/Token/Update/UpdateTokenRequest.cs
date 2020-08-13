using BlockbusterApp.src.Domain.TokenAggregate;
using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Application.UseCase.Token.Update
{
    public class UpdateTokenRequest : IRequest
    {

        public UpdateTokenRequest(Dictionary<string, string> Payload, Domain.TokenAggregate.Token Token)
        {
            this.Payload = Payload;
            this.Token = Token;
        }

        public Dictionary<string, string> Payload { get; set; }
        public Domain.TokenAggregate.Token Token { get; set; }
    }
}
