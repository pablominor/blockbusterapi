using BlockbusterApp.src.Application.UseCase.Category.FindById;
using BlockbusterApp.src.Domain.ProductAggregate;
using BlockbusterApp.src.Domain.ProductAggregate.Service;
using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using BlockbusterApp.src.Shared.Infraestructure.Bus.UseCase;


namespace BlockbusterApp.src.Infraestructure.Service.Product
{
    public class ProductFactory : IProductFactory
    {
        private IUseCaseBus useCaseBus;
        public ProductFactory(IUseCaseBus useCaseBus)
        {
            this.useCaseBus = useCaseBus;
        }


        public Domain.ProductAggregate.Product Create(string id, string name, string description, decimal price, string categoryId)
        {
            ProductId productId = ProductValueObjectsFactory.CreateProductId(id);
            ProductName productName = ProductValueObjectsFactory.CreateProductName(name);
            ProductDescription productDescription = ProductValueObjectsFactory.CreateProductDescription(description);
            ProductPrice productPrice = ProductValueObjectsFactory.CreateProductPrice(price);

            IResponse res = this.useCaseBus.Dispatch(new FindCategoryByIdRequest(categoryId));
            ProductCategoryId productCategoryId = ProductValueObjectsFactory.CreateProductCategoryId(categoryId);

            return Domain.ProductAggregate.Product.Create(
                productId,
                productName,
                productDescription,
                productPrice,
                productCategoryId);
        }
    }
}
