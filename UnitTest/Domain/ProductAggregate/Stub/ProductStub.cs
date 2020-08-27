using BlockbusterApp.src.Application.UseCase.Product.Create;
using BlockbusterApp.src.Domain.ProductAggregate;

namespace UnitTest.Domain.ProductAggregate.Stub
{
    public class ProductStub
    {
        public static BlockbusterApp.src.Domain.ProductAggregate.Product CreateFromRequest(CreateProductRequest request)
        {
            return Create(
                ProductIdStub.Create(request.Id),
                ProductNameStub.Create(request.Name),
                ProductDescriptionStub.Create(request.Description),
                ProductPriceStub.Create(request.Price),
                ProductCategoryIdStub.Create(request.CategoryId)
            );
        }

        public static BlockbusterApp.src.Domain.ProductAggregate.Product ByDefault()
        {
            return Create(
                ProductIdStub.ByDefault(),
                ProductNameStub.ByDefault(),
                ProductDescriptionStub.ByDefault(),
                ProductPriceStub.ByDefault(),
                ProductCategoryIdStub.ByDefault()
            );
        }


        private static BlockbusterApp.src.Domain.ProductAggregate.Product Create(
            ProductId id,
            ProductName name,
            ProductDescription description,
            ProductPrice price,
            ProductCategoryId categoryId)
        {
            return BlockbusterApp.src.Domain.ProductAggregate.Product.Create(
                id,
                name,
                description,
                price,
                categoryId);
        }
    }
}
