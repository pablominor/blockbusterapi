using BlockbusterApp.src.Shared.Domain.Exception;
using System;

namespace BlockbusterApp.src.Domain.ProductAggregate.Exception
{
    public class ProductFoundException : ValidationException
    {
        public ProductFoundException(string value) : base(value) { }

        public static ProductFoundException FromId(ProductId id)
        {
            return new ProductFoundException(String.Format("Product is already register with the id {0}.", id.GetValue()));
        }

        public static ProductFoundException FromName(ProductName name)
        {
            return new ProductFoundException(String.Format("Product is already register with the name {0}.", name.GetValue()));
        }
    }
}
