using System.Diagnostics.CodeAnalysis;

namespace BlockbusterApp.src.Shared.Domain.Exception
{
    
    public class ValidationException : WarningException
    {
        public ValidationException(string message) : base(message) { }
    }
}
