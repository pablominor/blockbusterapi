using BlockbusterApp.src.Shared.Domain.Exception;
using System;

namespace BlockbusterApp.src.Domain.ProductAggregate.Exception
{
    public class ProductNotFoundException : ValidationException
    {
        public ProductNotFoundException(string value) : base(value) { }

        public static ProductNotFoundException FromId(ProductId productId)
        {
            return new ProductNotFoundException(String.Format("Product with id {0} doesn't exists.", productId.GetValue()));
        }
    }
}
