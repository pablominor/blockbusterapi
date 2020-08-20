using BlockbusterApp.src.Shared.Domain.Exception;
using System;

namespace BlockbusterApp.src.Domain.CategoryAggregate.Exception
{
    public class CategoryFoundException : ValidationException
    {
        public CategoryFoundException(string value) : base(value) { }

        public static CategoryFoundException FromId(CategoryId id)
        {
            return new CategoryFoundException(String.Format("Category is already register with the id {0}.", id.GetValue()));
        }

        public static CategoryFoundException FromName(CategoryName name)
        {
            return new CategoryFoundException(String.Format("Category is already register with the name {0}.", name.GetValue()));
        }
    }
}
