using BlockbusterApp.src.Domain.UserAggregate;
using BlockbusterApp.src.Shared.Infraestructure.Persistance.Context;
using BlockbusterApp.src.Shared.Infraestructure.Persistance.Repository;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;

namespace BlockbusterApp.src.Infraestructure.Persistance.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {

        private readonly IServiceScopeFactory scopeFactory;

        public UserRepository(BlockbusterContext context, IServiceScopeFactory scopeFactory) : base(context)
        {
            this.scopeFactory = scopeFactory;
        }


        public User FindUserByEmail(UserEmail userEmail)
        {
            using(var scope = this.scopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<BlockbusterContext>();
                return dbContext.User.FirstOrDefault(c => c.userEmail.GetValue() == userEmail.GetValue());
            }
        }

        public void Add(User user)
        {
            using(var scope = this.scopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<BlockbusterContext>();
                dbContext.User.Add(user);                
            }
        }

        public List<User> GetUsers(Dictionary<string, int> page)
        {
            using(var scope = this.scopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<BlockbusterContext>();
                return dbContext.User.Skip((page["number"] - 1) * page["size"]).Take(page["size"]).ToList();
            }
        }

        public User FindUserById(UserId userId)
        {
            using (var scope = this.scopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<BlockbusterContext>();                
                return dbContext.User.FirstOrDefault(c => c.userId.GetValue() == userId.GetValue());
            }
        }

        public User FindUserByEmailAndPassword(UserEmail email, UserHashedPassword hashedPassword)
        {
            using (var scope = this.scopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<BlockbusterContext>();
                return dbContext.User.FirstOrDefault(c => c.userEmail.GetValue() == email.GetValue() && c.userHashedPassword.GetValue() == hashedPassword.GetValue());
            }
        }
    }
}
