using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Shared.Domain.Exception
{
    public class WarningException : Exception
    {
        public WarningException(string message) : base(message) { }
    }
}
