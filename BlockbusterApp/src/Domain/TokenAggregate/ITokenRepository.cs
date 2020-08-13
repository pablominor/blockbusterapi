using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Domain.TokenAggregate
{
    public interface ITokenRepository
    {
        void Add(Token token);
        void Update(Token token);
        Token FindByUserId(TokenUserId tokenUserId);
    }
}
