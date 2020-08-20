using BlockbusterApp.src.Shared.Domain.Exception;
using System;

namespace BlockbusterApp.src.Domain.CategoryAggregate.Exception
{
    public class CategoryNotFoundException : ValidationException
    {
        public CategoryNotFoundException(string value) : base(value) { }

        public static CategoryNotFoundException FromId(CategoryId categoryId)
        {
            return new CategoryNotFoundException(String.Format("Category with id {0} doesn't exists.", categoryId.GetValue()));
        }
    }
}
