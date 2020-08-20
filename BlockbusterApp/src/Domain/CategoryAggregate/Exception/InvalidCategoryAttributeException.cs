using BlockbusterApp.src.Shared.Domain.Exception;

namespace BlockbusterApp.src.Domain.CategoryAggregate.Exception
{
    public class InvalidCategoryAttributeException : InvalidAttributeException
    {
        public InvalidCategoryAttributeException(string message) : base(message) { }
    }
}
