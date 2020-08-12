using System.Diagnostics.CodeAnalysis;

namespace BlockbusterApp.src.Shared.Domain.Exception
{
    [ExcludeFromCodeCoverage]
    public class Exception : System.Exception
    {
        public Exception(string message) : base(message) { }
    }
}
