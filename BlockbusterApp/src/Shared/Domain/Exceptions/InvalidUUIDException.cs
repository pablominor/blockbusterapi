﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Shared.Domain.Exceptions
{
    public class InvalidUUIDException : InvalidAttributeException
    {
        public InvalidUUIDException(string message) : base(message) { }
    }
}
