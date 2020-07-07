using BlockbusterApp.src.Domain.UserAggregate;
using BlockbusterApp.src.Shared.Infraestructure.Persistance.Context;
using BlockbusterApp.src.Shared.Infraestructure.Persistance.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Infraestructure.Persistance.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {

        private readonly IServiceScopeFactory _scopeFactory;

        public UserRepository(BlockbusterContext context, IServiceScopeFactory scopeFactory) : base(context)
        {
            _scopeFactory = scopeFactory;
        }


        public User FindUserByEmail(UserEmail userEmail)
        {
            using(var scope = _scopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<BlockbusterContext>();
                return dbContext.Users.FirstOrDefault(c => c.userEmail.GetValue() == userEmail.GetValue());
            }
        }

        public void Add(User user)
        {
            using(var scope = _scopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<BlockbusterContext>();
                dbContext.Users.Add(user);
            }
        }

        public List<User> GetUsers(Dictionary<string, int> page)
        {
            using(var scope = _scopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<BlockbusterContext>();
                return dbContext.Users.Skip((page["number"] - 1) * page["size"]).Take(page["size"]).ToList();
            }
        }
    }
}
