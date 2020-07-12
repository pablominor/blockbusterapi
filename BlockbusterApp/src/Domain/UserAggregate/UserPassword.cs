using BlockbusterApp.src.Domain.UserAggregate.Exception;
using BlockbusterApp.src.Shared.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Domain.UserAggregate
{
    public class UserPassword : StringValueObject
    {
        private const string PATTERN = "([a-zA-Z0-9]{8,15})";
        public UserPassword(string value) : base(value)
        {
            if (!this.Is(value))
            {
                throw InvalidUserAttributeException.FromValue("password", value);
            }
        }

        private bool Is(string value)
        {
            Regex regex = new Regex(UserPassword.PATTERN);
            Match match = regex.Match(value);

            if (match.Success)
            {
                return true;
            }
            return false;
        }

        public static void Validate(string password, string repeatPassword)
        {
            if (password != repeatPassword)
            {
                throw InvalidUserAttributeException.FromText("Password must be equal than repeat password");
            }
        }
    }
}
