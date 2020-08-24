using BlockbusterApp.src.Shared.Domain.Exception;

namespace BlockbusterApp.src.Domain.ProductAggregate.Exception
{
    public class InvalidProductAttributeException : InvalidAttributeException
    {
        public InvalidProductAttributeException(string message) : base(message) { }
    }
}
