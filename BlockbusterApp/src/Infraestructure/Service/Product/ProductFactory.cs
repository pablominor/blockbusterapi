using BlockbusterApp.src.Application.UseCase.Category.FindById;
using BlockbusterApp.src.Domain.ProductAggregate;
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
            ProductId productId = new ProductId(id);
            ProductName productName = new ProductName(name);
            ProductDescription productDescription = new ProductDescription(description);
            ProductPrice productPrice = new ProductPrice(price);

            IResponse res = this.useCaseBus.Dispatch(new FindCategoryByIdRequest(categoryId));
            ProductCategoryId productCategoryId = new ProductCategoryId(categoryId);

            return Domain.ProductAggregate.Product.Create(
                productId,
                productName,
                productDescription,
                productPrice,
                productCategoryId);
        }
    }
}
