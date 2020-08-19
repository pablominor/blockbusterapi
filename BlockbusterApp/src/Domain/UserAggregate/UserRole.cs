using BlockbusterApp.src.Domain.UserAggregate.Exception;
using BlockbusterApp.src.Shared.Domain;

namespace BlockbusterApp.src.Domain.UserAggregate
{
    public class UserRole : StringValueObject
    {
        public const string ROLE_ADMIN = "Admin";
        public const string ROLE_USER = "User";
        public const string ROLE_ADMIN_OR_USER = ROLE_ADMIN +","+ ROLE_USER;

        public UserRole(string value) : base(value)
        {
            if(!value.Equals(ROLE_ADMIN) && !value.Equals(ROLE_USER))
            {
                throw InvalidUserAttributeException.FromText("This role is not correct");
            }
        }
    }
}
