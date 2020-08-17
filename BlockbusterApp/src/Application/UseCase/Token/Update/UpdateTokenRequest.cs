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

        public UpdateTokenRequest(string tokenUserId, string tokenHash)
        {
            this.tokenUserId = tokenUserId;
            this.tokenHash = tokenHash;
        }

        public string tokenUserId { get; set; }
        public string tokenHash { get; set; }
    }
}
