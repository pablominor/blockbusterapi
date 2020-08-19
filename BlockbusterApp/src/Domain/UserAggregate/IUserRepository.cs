using System.Collections.Generic;

namespace BlockbusterApp.src.Domain.UserAggregate
{
    public interface IUserRepository
    {
        void Add(User user);
        void Update(User user);
        User FindUserByEmail(UserEmail email);
        List<User> GetUsers(Dictionary<string, int> page);
        User FindUserById(UserId id);
        User FindUserByEmailAndPassword(UserEmail email,UserHashedPassword hashedPassword);
    }
}
