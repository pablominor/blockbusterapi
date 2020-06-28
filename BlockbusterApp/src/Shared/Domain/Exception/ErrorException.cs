using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Shared.Domain.Exception
{
    public class ErrorException : Exception
    {
        public ErrorException(string message) : base(message) { }
    }
}
