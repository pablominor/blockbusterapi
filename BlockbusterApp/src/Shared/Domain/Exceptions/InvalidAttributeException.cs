﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Shared.Domain.Exceptions
{
    public class InvalidAttributeException : ValidationException
    {
        public InvalidAttributeException(string message) : base(message) { }

        public static InvalidUUIDException FromText(string text)
        {
            return new InvalidUUIDException(text);
        }

        public static InvalidUUIDException FromEmpty(string attribute)
        {
            return new InvalidUUIDException(string.Format("the {0} must not be empty", attribute));
        }

        public static InvalidUUIDException FromValue(string attribute, string value)
        {
            return new InvalidUUIDException(string.Format("the {0} is invalid because of its value {1}", attribute, value));
        }

        public static InvalidUUIDException FromMaxLength(string attribute, int length)
        {
            return new InvalidUUIDException(string.Format("length {0} cannot be more than {1} characters.", attribute, length.ToString()));
        }

        public static InvalidUUIDException FromMinLength(string attribute, int length)
        {
            return new InvalidUUIDException(string.Format("length {0} cannot be less than {1} characters.", attribute, length.ToString()));
        }
    }
}
