using BlockbusterApp.src.Domain.UserAggregate.Event;
using BlockbusterApp.src.Shared.Domain;
using System;
using System.Collections.Generic;

namespace BlockbusterApp.src.Domain.UserAggregate
{
    public class User : AggregateRoot
    {
        public UserId userId { get; }
        public UserEmail userEmail{ get; }
        public UserHashedPassword userHashedPassword{ get; private set; }
        public UserFirstName userFirstName{ get; private set;}
        public UserLastName userLastName{ get; private set; }
        public UserRole userRole{ get; }
        public UserCountryCode userCountryCode { get; }
        public UserCreatedAt userCreatedAt{ get; }
        public UserUpdatedAt userUpdatedAt{ get; private set; }

        private User(
            UserId userId,
            UserEmail userEmail,
            UserHashedPassword userHashedPassword,
            UserFirstName userFirstName,
            UserLastName userLastName,
            UserRole userRole,
            UserCountryCode userCountryCode,
            UserCreatedAt userCreatedAt,
            UserUpdatedAt userUpdatedAt)
        {
            this.userId = userId;
            this.userEmail = userEmail;
            this.userHashedPassword = userHashedPassword;
            this.userFirstName = userFirstName;
            this.userLastName = userLastName;
            this.userRole = userRole;
            this.userCountryCode = userCountryCode;
            this.userCreatedAt = userCreatedAt;
            this.userUpdatedAt = userUpdatedAt;
        }

        public static User SignUp(
            UserId userId,
            UserEmail userEmail,
            UserHashedPassword userHashedPassword,
            UserFirstName userFirstName,
            UserLastName userLastName,
            UserRole userRole,
            UserCountryCode userCountryCode
            )          
        {
            UserCreatedAt userCreatedAt = new UserCreatedAt(DateTime.Now);
            UserUpdatedAt userUpdatedAt = new UserUpdatedAt(DateTime.Now);
            User user = new User(userId, userEmail, userHashedPassword, 
                userFirstName, userLastName, userRole, userCountryCode, userCreatedAt, userUpdatedAt);

            user.Record(new UserSignedUpEvent(user.userId.GetValue(),
                new Dictionary<string, string>()
                {
                    ["email"] = user.userEmail.GetValue(),
                    ["firstname"] = user.userFirstName.GetValue(),
                    ["lastname"] = user.userLastName.GetValue(),
                    ["role"] = user.userRole.GetValue(),
                    ["country_code"] = user.userCountryCode.GetValue()
                }
            ));

            return user;
        }


        public void Update(UserHashedPassword password, UserFirstName firstName, UserLastName lastName)
        {
            UpdatePassword(password);
            UpdateFirstName(firstName);
            UpdateLastName(lastName);
        }


        private void UpdatePassword(UserHashedPassword password)
        {
            if (!password.Equals(this.userHashedPassword))
            {
                this.userHashedPassword = password;
                UpdateUserUpdatedAt();
            }
        }

        private void UpdateFirstName(UserFirstName firstName)
        {
            if (!firstName.Equals(this.userFirstName))
            {
                this.userFirstName = firstName;
                UpdateUserUpdatedAt();
            }
        }

        private void UpdateLastName(UserLastName lastName)
        {
            if (!lastName.Equals(this.userLastName))
            {
                this.userLastName = lastName;
                UpdateUserUpdatedAt();
            }
        }

        private void UpdateUserUpdatedAt()
        {
            this.userUpdatedAt = new UserUpdatedAt(DateTime.Now);
        }
    }
}
