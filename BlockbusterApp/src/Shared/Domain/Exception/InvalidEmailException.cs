using System.Diagnostics.CodeAnalysis;

namespace BlockbusterApp.src.Shared.Domain.Exception
{
    
    public class InvalidEmailException : InvalidAttributeException
    {
        public InvalidEmailException(string message) : base(message) { }
    }
}
