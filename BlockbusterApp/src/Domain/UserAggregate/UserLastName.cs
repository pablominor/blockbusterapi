using BlockbusterApp.src.Domain.UserAggregate.Exception;
using BlockbusterApp.src.Shared.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Domain.UserAggregate
{
    public class UserLastName : StringValueObject
    {
        public const int MIN_LENGTH = 3;
        public const int MAX_LENGTH = 30;

        public UserLastName(string value) : base(value)
        {
            if(value.Length < MIN_LENGTH)
            {
                throw InvalidUserAttributeException.FromMinLength("last name", MIN_LENGTH);
            }
            if(value.Length > MAX_LENGTH)
            {
                throw InvalidUserAttributeException.FromMaxLength("last name", MAX_LENGTH);
            }
        }
    }
}
