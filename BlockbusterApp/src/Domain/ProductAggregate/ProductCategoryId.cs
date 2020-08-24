using BlockbusterApp.src.Shared.Domain;

namespace BlockbusterApp.src.Domain.ProductAggregate
{
    public class ProductCategoryId : UUID
    {
        public ProductCategoryId(string value) : base(value)
        {

        }
    }
}
