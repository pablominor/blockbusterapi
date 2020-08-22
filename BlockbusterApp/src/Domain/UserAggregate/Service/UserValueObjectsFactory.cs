namespace BlockbusterApp.src.Domain.UserAggregate.Service
{
    public class UserValueObjectsFactory
    {
        public static UserId CreateUserId(string id)
        {
            return new UserId(id);
        }

        public static UserEmail CreateUserEmail(string email)
        {
            return new UserEmail(email);
        }

        public static UserPassword CreateUserPassword(string password)
        {
            return new UserPassword(password);
        }

        public static UserFirstName CreateUserFirstName(string firstName)
        {
            return new UserFirstName(firstName);
        }

        public static UserLastName CreateUserLastName(string lastName)
        {
            return new UserLastName(lastName);
        }

        public static UserRole CreateUserRole(string role)
        {
            return new UserRole(role);
        }

        public static UserCountryCode CreateUserCountryCode(string countryCode)
        {
            return new UserCountryCode(countryCode);
        }


    }
}
