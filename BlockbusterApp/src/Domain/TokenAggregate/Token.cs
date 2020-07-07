using BlockbusterApp.src.Domain.TokenAggregate.Event;
using BlockbusterApp.src.Shared.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Domain.TokenAggregate
{
    public class Token : AggregateRoot
    {

        public TokenHash tokenHash { get; }
        public TokenUserId tokenUserId { get; }
        public TokenCreatedAt tokenCreatedAt { get; }
        public TokenUpdatedAt tokenUpdatedAt { get; }

        private Token(
            TokenHash tokenHash, 
            TokenUserId tokenUserId,
            TokenCreatedAt tokenCreatedAt,
            TokenUpdatedAt tokenUpdatedAt)
        {
            this.tokenHash = tokenHash;
            this.tokenUserId = tokenUserId;
            this.tokenCreatedAt = tokenCreatedAt;
            this.tokenUpdatedAt = tokenUpdatedAt;
        }

        public static Token Create(TokenHash tokenHash, TokenUserId tokenUserId)
        {
            TokenCreatedAt tokenCreatedAt = new TokenCreatedAt(DateTime.Now);
            TokenUpdatedAt tokenUpdatedAt = new TokenUpdatedAt(DateTime.Now);

            Token token = new Token(tokenHash, tokenUserId, tokenCreatedAt, tokenUpdatedAt);

            token.Record(new TokenCreatedEvent(
                token.tokenUserId.GetValue(),
                new Dictionary<string, string>()
                {
                    ["hash"] = token.tokenHash.GetValue(),
                    ["user_id"] = token.tokenUserId.GetValue(),
                    ["created_at"] = token.tokenCreatedAt.GetValue().ToString(),
                    ["updated_at"] = token.tokenUpdatedAt.GetValue().ToString()
                }
            ));

            return token;
        } 
    }
}
