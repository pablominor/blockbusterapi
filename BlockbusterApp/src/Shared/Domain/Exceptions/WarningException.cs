using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Shared.Domain.Exceptions
{
    public class WarningException : Exception
    {
        public WarningException(string message) : base(message) { }
    }
}
