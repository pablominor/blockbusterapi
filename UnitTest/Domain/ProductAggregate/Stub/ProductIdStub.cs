using BlockbusterApp.src.Domain.ProductAggregate;

namespace UnitTest.Domain.ProductAggregate.Stub
{
    public class ProductIdStub
    {
        public static ProductId Create(string id)
        {
            return new ProductId(id);
        }

        public static ProductId ByDefault()
        {
            return new ProductId("a5fe8c53-5261-47aa-9c3d-3059cf90d6f1");
        }
    }
}
