using BlockbusterApp.src.Shared.Domain;
using System;

namespace BlockbusterApp.src.Domain.ProductAggregate
{
    public class ProductCreatedAt : DateTimeValueObject
    {
        public ProductCreatedAt(DateTime value) : base(value)
        {

        }
    }
}
