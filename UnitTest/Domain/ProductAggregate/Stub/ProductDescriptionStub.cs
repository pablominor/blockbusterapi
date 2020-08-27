using BlockbusterApp.src.Domain.ProductAggregate;

namespace UnitTest.Domain.ProductAggregate.Stub
{
    public class ProductDescriptionStub
    {
        public static ProductDescription Create(string description)
        {
            return new ProductDescription(description);
        }

        public static ProductDescription ByDefault()
        {
            return new ProductDescription("this is the description");
        }
    }
}
