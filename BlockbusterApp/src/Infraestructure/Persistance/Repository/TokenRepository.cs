﻿using BlockbusterApp.src.Domain.TokenAggregate;
using BlockbusterApp.src.Shared.Infraestructure.Persistance.Context;
using BlockbusterApp.src.Shared.Infraestructure.Persistance.Repository;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace BlockbusterApp.src.Infraestructure.Persistance.Repository
{
    public class TokenRepository : Repository<Token>, ITokenRepository
    {
        private readonly IServiceScopeFactory scopeFactory;

        public TokenRepository(BlockbusterContext context, IServiceScopeFactory scopeFactory) : base(context)
        {
            this.scopeFactory = scopeFactory;
        }


        public void Add(Token token)
        {
            using (var scope = this.scopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<BlockbusterContext>();
                dbContext.Token.Add(token);
            }
        }

        public void Update(Token token)
        {
            using (var scope = this.scopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<BlockbusterContext>();
                dbContext.Token.Update(token);
            }
        }

        public void Remove(Token token)
        {
            using (var scope = this.scopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<BlockbusterContext>();
                dbContext.Token.Remove(token);
            }
        }

        public Token FindByUserId(TokenUserId tokenUserId)
        {
            using (var scope = this.scopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<BlockbusterContext>();
                return dbContext.Token.FirstOrDefault(c => c.userId.GetValue() == tokenUserId.GetValue());
            }
        }

        public Token FindByUserIdAndHash(TokenUserId tokenUserId,TokenHash tokenHash)
        {
            using (var scope = this.scopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<BlockbusterContext>();
                return dbContext.Token.FirstOrDefault(c => c.userId.GetValue() == tokenUserId.GetValue() && c.hash.GetValue() == tokenHash.GetValue());
            }
        }
    }
}
