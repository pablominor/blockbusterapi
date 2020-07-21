using BlockbusterApp.src.Shared.Domain.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Shared.Domain
{
    public class CountryCode : StringValueObject
    {
        public const int MIN_LENGTH = 2;
        public const int MAX_LENGTH = 2;

        public CountryCode(string value) : base(value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw InvalidUUIDException.FromEmpty("country code");
            }
            if (value.Length < MIN_LENGTH)
            {
                throw InvalidCountryCodeException.FromMinLength("country code", MIN_LENGTH);
            }
            if (value.Length > MAX_LENGTH)
            {
                throw InvalidCountryCodeException.FromMaxLength("country code", MAX_LENGTH);
            }
        }        
    }
}
