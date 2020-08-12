using System.Diagnostics.CodeAnalysis;

namespace BlockbusterApp.src.Shared.Domain.Exception
{
    [ExcludeFromCodeCoverage]
    public class WarningException : Exception
    {
        public WarningException(string message) : base(message) { }
    }
}
