using System.Diagnostics.CodeAnalysis;

namespace BlockbusterApp.src.Shared.Domain.Exception
{
    
    public class InvalidCountryCodeException : InvalidAttributeException
    {
        public InvalidCountryCodeException(string message) : base(message) { }
    }
}
