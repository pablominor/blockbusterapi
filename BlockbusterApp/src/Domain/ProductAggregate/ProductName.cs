using BlockbusterApp.src.Domain.ProductAggregate.Exception;
using BlockbusterApp.src.Shared.Domain;

namespace BlockbusterApp.src.Domain.ProductAggregate
{
    public class ProductName : StringValueObject
    {
        public const int MIN_LENGTH = 3;
        public const int MAX_LENGTH = 30;

        public ProductName(string value) : base(value)
        {
            if (value.Length < MIN_LENGTH)
            {
                throw InvalidProductAttributeException.FromMinLength("name", MIN_LENGTH);
            }
            if (value.Length > MAX_LENGTH)
            {
                throw InvalidProductAttributeException.FromMaxLength("name", MAX_LENGTH);
            }
        }
    }
}
