using BlockbusterApp.src.Domain.ProductAggregate.Exception;
using BlockbusterApp.src.Shared.Domain;

namespace BlockbusterApp.src.Domain.ProductAggregate
{
    public class ProductPrice : DecimalValueObject
    {
        public ProductPrice(decimal value) : base(value)
        {
            if (value == 0 || value < 0)
            {
                throw InvalidProductAttributeException.FromValue("price", value.ToString());
            }            
        }
    }
}
