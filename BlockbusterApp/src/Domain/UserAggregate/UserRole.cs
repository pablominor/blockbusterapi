using BlockbusterApp.src.Domain.UserAggregate.Exception;
using BlockbusterApp.src.Shared.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Domain.UserAggregate
{
    public class UserRole : StringValueObject
    {
        public const string ROLE_ADMIN = "Admin";
        public const string ROLE_USER = "User";

        public UserRole(string value) : base(value)
        {
            if(!value.Equals(ROLE_ADMIN) && !value.Equals(ROLE_USER))
            {
                throw InvalidUserAttributeException.FromText("This role is not correct");
            }
        }
    }
}
