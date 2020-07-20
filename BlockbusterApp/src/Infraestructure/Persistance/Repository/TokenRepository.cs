using BlockbusterApp.src.Domain.TokenAggregate;
using BlockbusterApp.src.Shared.Infraestructure.Persistance.Context;
using BlockbusterApp.src.Shared.Infraestructure.Persistance.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Infraestructure.Persistance.Repository
{
    public class TokenRepository : Repository<Token>, ITokenRepository
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public TokenRepository(BlockbusterContext context, IServiceScopeFactory scopeFactory) : base(context)
        {
            _scopeFactory = scopeFactory;
        }


        public void Add(Token token)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<BlockbusterContext>();
                dbContext.Token.Add(token);
            }
        }
    }
}
