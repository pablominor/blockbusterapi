using System.Diagnostics.CodeAnalysis;

namespace BlockbusterApp.src.Shared.Domain.Exception
{
    [ExcludeFromCodeCoverage]
    public class ValidationException : WarningException
    {
        public ValidationException(string message) : base(message) { }
    }
}
