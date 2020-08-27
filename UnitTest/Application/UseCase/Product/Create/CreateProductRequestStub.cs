using BlockbusterApp.src.Application.UseCase.Product.Create;
using UnitTest.Domain.ProductAggregate.Stub;

namespace UnitTest.Application.UseCase.Product.Create
{
    public class CreateProductRequestStub
    {
        public static CreateProductRequest ByDefault()
        {
            return new CreateProductRequest(
                ProductIdStub.ByDefault().GetValue(),
                ProductNameStub.ByDefault().GetValue(),
                ProductDescriptionStub.ByDefault().GetValue(),
                ProductPriceStub.ByDefault().GetValue(),
                ProductCategoryIdStub.ByDefault().GetValue());
        }
    }
}
