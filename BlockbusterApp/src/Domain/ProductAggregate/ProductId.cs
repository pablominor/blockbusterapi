using BlockbusterApp.src.Shared.Domain;

namespace BlockbusterApp.src.Domain.ProductAggregate
{
    public class ProductId : UUID
    {
        public ProductId(string value) : base(value)
        {

        }
    }
}
