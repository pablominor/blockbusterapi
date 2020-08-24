using BlockbusterApp.src.Shared.Domain;
using System;

namespace BlockbusterApp.src.Domain.ProductAggregate
{
    public class ProductUpdatedAt : DateTimeValueObject
    {
        public ProductUpdatedAt(DateTime value) : base(value)
        {

        }
    }
}
