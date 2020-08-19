using BlockbusterApp.src.Domain.UserAggregate;
using BlockbusterApp.src.Domain.UserAggregate.Service;
using BlockbusterApp.src.Infraestructure.Service.Hashing;

namespace BlockbusterApp.src.Infraestructure.Service.User
{
    public class UserUpdater : IUserUpdater
    {
        private UserFinder userFinder;
        private IHashing hashing;

        public UserUpdater(UserFinder userFinder,IHashing hashing)
        {
            this.userFinder = userFinder;
            this.hashing = hashing;
        }


        public Domain.UserAggregate.User Update(string id,string password, string firstName, string lastName)
        {
            UserId userId = new UserId(id);
            Domain.UserAggregate.User user = this.userFinder.ById(userId);

            UserHashedPassword userHashedPassword = this.hashing.Hash(password);
            UserFirstName userFirstName = new UserFirstName(firstName);
            UserLastName userLastName = new UserLastName(lastName);

            user.UpdatePassword(userHashedPassword);
            user.UpdateFirstName(userFirstName);
            user.UpdateLastName(userLastName);

            return user;
        }
    }
}
