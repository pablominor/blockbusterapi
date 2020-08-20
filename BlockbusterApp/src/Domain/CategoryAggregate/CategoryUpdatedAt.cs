using BlockbusterApp.src.Shared.Domain;
using System;

namespace BlockbusterApp.src.Domain.CategoryAggregate
{
    public class CategoryUpdatedAt : DateTimeValueObject
    {
        public CategoryUpdatedAt(DateTime value) : base(value)
        {

        }
    }
}
