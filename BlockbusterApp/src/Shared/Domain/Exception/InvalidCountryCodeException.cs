using System.Diagnostics.CodeAnalysis;

namespace BlockbusterApp.src.Shared.Domain.Exception
{
    [ExcludeFromCodeCoverage]
    public class InvalidCountryCodeException : InvalidAttributeException
    {
        public InvalidCountryCodeException(string message) : base(message) { }
    }
}
