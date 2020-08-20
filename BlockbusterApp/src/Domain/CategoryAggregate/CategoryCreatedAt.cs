using BlockbusterApp.src.Shared.Domain;
using System;

namespace BlockbusterApp.src.Domain.CategoryAggregate
{
    public class CategoryCreatedAt : DateTimeValueObject
    {
        public CategoryCreatedAt(DateTime value) : base(value)
        {

        }
    }
}
