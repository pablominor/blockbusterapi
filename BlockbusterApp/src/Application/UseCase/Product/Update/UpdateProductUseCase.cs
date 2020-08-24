using BlockbusterApp.src.Application.UseCase.Category.FindById;
using BlockbusterApp.src.Domain.ProductAggregate;
using BlockbusterApp.src.Domain.ProductAggregate.Service;
using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using BlockbusterApp.src.Shared.Infraestructure.Bus.UseCase;
using System;

namespace BlockbusterApp.src.Application.UseCase.Product.Update
{
    public class UpdateProductUseCase : IUseCase
    {

        private ProductFinder productFinder;
        private IUseCaseBus useCaseBus;
        private IProductRepository productRepository;
        private EmptyResponseConverter converter;

        public UpdateProductUseCase(
            ProductFinder productFinder,
            IUseCaseBus useCaseBus,
            IProductRepository productRepository,
            EmptyResponseConverter converter)
        {
            this.productFinder = productFinder;
            this.useCaseBus = useCaseBus;
            this.productRepository = productRepository;
            this.converter = converter;
        }


        public IResponse Execute(IRequest req)
        {
            UpdateProductRequest request = req as UpdateProductRequest;

            ProductId productId = ProductValueObjectsFactory.CreateProductId(request.Id);
            Domain.ProductAggregate.Product product = this.productFinder.FindOneById(productId);

            IResponse res = this.useCaseBus.Dispatch(new FindCategoryByIdRequest(request.CategoryId));
            
            ProductCategoryId productCategoryId = ProductValueObjectsFactory.CreateProductCategoryId(request.CategoryId);
            ProductName productName = ProductValueObjectsFactory.CreateProductName(request.Name);
            ProductDescription productDescription = ProductValueObjectsFactory.CreateProductDescription(request.Description);
            ProductPrice productPrice = ProductValueObjectsFactory.CreateProductPrice(request.Price);

            product.Update(productName, productDescription, productPrice, productCategoryId);

            this.productRepository.Update(product);

            return this.converter.Convert();
        }
    }
}
