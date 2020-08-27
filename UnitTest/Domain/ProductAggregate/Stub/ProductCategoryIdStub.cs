using BlockbusterApp.src.Domain.ProductAggregate;
using UnitTest.Domain.CategoryAggregate.Stub;

namespace UnitTest.Domain.ProductAggregate.Stub
{
    public class ProductCategoryIdStub
    {
        public static ProductCategoryId Create(string id)
        {
            return new ProductCategoryId(id);
        }

        public static ProductCategoryId ByDefault()
        {
            return new ProductCategoryId(CategoryIdStub.ByDefault().GetValue());
        }
    }
}
