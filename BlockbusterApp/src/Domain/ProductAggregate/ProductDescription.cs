using BlockbusterApp.src.Domain.ProductAggregate.Exception;
using BlockbusterApp.src.Shared.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Domain.ProductAggregate
{
    public class ProductDescription : StringValueObject
    {
        public const int MIN_LENGTH = 3;
        public const int MAX_LENGTH = 1300;

        public ProductDescription(string value) : base(value)
        {
            if (value.Length < MIN_LENGTH)
            {
                throw InvalidProductAttributeException.FromMinLength("description", MIN_LENGTH);
            }
            if (value.Length > MAX_LENGTH)
            {
                throw InvalidProductAttributeException.FromMaxLength("description", MAX_LENGTH);
            }
        }
    }
}
