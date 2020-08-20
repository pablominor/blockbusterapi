using BlockbusterApp.src.Domain.CategoryAggregate.Exception;
using BlockbusterApp.src.Shared.Domain;

namespace BlockbusterApp.src.Domain.CategoryAggregate
{
    public class CategoryName : StringValueObject
    {
        public const int MIN_LENGTH = 3;
        public const int MAX_LENGTH = 30;

        public CategoryName(string value) : base(value)
        {
            if (value.Length < MIN_LENGTH)
            {
                throw InvalidCategoryAttributeException.FromMinLength("name", MIN_LENGTH);
            }
            if (value.Length > MAX_LENGTH)
            {
                throw InvalidCategoryAttributeException.FromMaxLength("name", MAX_LENGTH);
            }
        }
    }
}
