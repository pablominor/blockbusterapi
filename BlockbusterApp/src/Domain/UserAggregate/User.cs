using BlockbusterApp.src.Domain.UserAggregate.Event;
using BlockbusterApp.src.Shared.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Domain.UserAggregate
{
    public class User : AggregateRoot
    {
        public UserId userId { get; }
        public UserEmail userEmail{ get; }
        public UserHashedPassword userHashedPassword{ get; }
        public UserFirstName userFirstName{ get; }
        public UserLastName userLastName{ get; }
        public UserRole userRole{ get; }
        public UserCreatedAt userCreatedAt{ get; }
        public UserUpdatedAt userUpdatedAt{ get; }

        private User(
            UserId userId,
            UserEmail userEmail,
            UserHashedPassword userHashedPassword,
            UserFirstName userFirstName,
            UserLastName userLastName,
            UserRole userRole,
            UserCreatedAt userCreatedAt,
            UserUpdatedAt userUpdatedAt)
        {
            this.userId = userId;
            this.userEmail = userEmail;
            this.userHashedPassword = userHashedPassword;
            this.userFirstName = userFirstName;
            this.userLastName = userLastName;
            this.userRole = userRole;
            this.userCreatedAt = userCreatedAt;
            this.userUpdatedAt = userUpdatedAt;
        }

        public static User SignUp(
            UserId userId,
            UserEmail userEmail,
            UserHashedPassword userHashedPassword,
            UserFirstName userFirstName,
            UserLastName userLastName,
            UserRole userRole
            )          
        {
            UserCreatedAt userCreatedAt = new UserCreatedAt(DateTime.Now);
            UserUpdatedAt userUpdatedAt = new UserUpdatedAt(DateTime.Now);
            User user = new User(userId, userEmail, userHashedPassword, 
                userFirstName, userLastName, userRole, userCreatedAt, userUpdatedAt);

            user.Record(new UserSignedUpEvent(user.userId.GetValue(),
                new Dictionary<string, string>()
                {
                    ["email"] = user.userEmail.GetValue(),
                    ["firstname"] = user.userFirstName.GetValue(),
                    ["lastname"] = user.userLastName.GetValue(),
                    ["role"] = user.userRole.GetValue()
                }
            ));

            return user;
        }
    }
}
