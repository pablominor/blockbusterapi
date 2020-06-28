using BlockbusterApp.src.Domain.UserAggregate.Exception;
using BlockbusterApp.src.Shared.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Domain.UserAggregate
{
    public class UserFirstName : StringValueObject
    {
        private const int MIN_LENGTH = 3;
        private const int MAX_LENGTH = 15;

        public UserFirstName(string value) : base(value)
        {
            if(value.Length < MIN_LENGTH)
            {
                throw InvalidUserAttributeException.FromMinLength("first name", MIN_LENGTH);
            }
            if(value.Length > MAX_LENGTH)
            {
                throw InvalidUserAttributeException.FromMaxLength("first name", MAX_LENGTH);
            }
        }
    }
}
