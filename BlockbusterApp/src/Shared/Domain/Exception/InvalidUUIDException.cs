using System.Diagnostics.CodeAnalysis;

namespace BlockbusterApp.src.Shared.Domain.Exception
{
    [ExcludeFromCodeCoverage]
    public class InvalidUUIDException : InvalidAttributeException
    {
        public InvalidUUIDException(string message) : base(message) { }
    }
}
