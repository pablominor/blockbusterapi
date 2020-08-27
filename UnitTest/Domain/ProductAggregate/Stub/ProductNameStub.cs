using BlockbusterApp.src.Domain.ProductAggregate;

namespace UnitTest.Domain.ProductAggregate.Stub
{
    public class ProductNameStub
    {
        public static ProductName Create(string name)
        {
            return new ProductName(name);
        }

        public static ProductName ByDefault()
        {
            return new ProductName("terminator");
        }
    }
}
