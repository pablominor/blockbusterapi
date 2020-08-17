using System.Diagnostics.CodeAnalysis;

namespace BlockbusterApp.src.Shared.Domain.Exception
{
    
    public class SecurityException : Exception
    {
        public SecurityException(string message) : base(message) { }
    }
}
