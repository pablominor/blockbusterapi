using System.Diagnostics.CodeAnalysis;

namespace BlockbusterApp.src.Shared.Domain.Exception
{
    
    public class ErrorException : Exception
    {
        public ErrorException(string message) : base(message) { }
    }
}
