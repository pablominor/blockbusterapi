using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Shared.Domain.Exceptions
{
    public class ValidationException : WarningException
    {
        public ValidationException(string message) : base(message) { }
    }
}
