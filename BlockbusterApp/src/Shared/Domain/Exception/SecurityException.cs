using System.Diagnostics.CodeAnalysis;

namespace BlockbusterApp.src.Shared.Domain.Exception
{
    [ExcludeFromCodeCoverage]
    public class SecurityException : Exception
    {
        public SecurityException(string message) : base(message) { }
    }
}
