using BlockbusterApp.src.Domain.ProductAggregate;

namespace UnitTest.Domain.ProductAggregate.Stub
{
    public class ProductPriceStub
    {
        public static ProductPrice Create(decimal price)
        {
            return new ProductPrice(price);
        }

        public static ProductPrice ByDefault()
        {
            return new ProductPrice(10);
        }
    }
}
