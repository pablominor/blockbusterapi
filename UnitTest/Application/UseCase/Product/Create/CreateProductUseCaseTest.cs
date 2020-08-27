using BlockbusterApp.src.Application.UseCase.Product.Create;
using BlockbusterApp.src.Domain.ProductAggregate;
using BlockbusterApp.src.Domain.ProductAggregate.Service;
using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using Moq;
using NUnit.Framework;
using UnitTest.Domain.ProductAggregate.Stub;
using UnitTest.Domain.Repository;

namespace UnitTest.Application.UseCase.Product.Create
{
    [TestFixture]
    public class CreateProductUseCaseTest
    {
        [Test]
        public void ItShouldCallCollaborators()
        {
            CreateProductRequest request = CreateProductRequestStub.ByDefault();
            BlockbusterApp.src.Domain.ProductAggregate.Product product = ProductStub.ByDefault();
            Mock<IProductFactory> productFactory = new Mock<IProductFactory>();
            productFactory.Setup(o => o.Create(
                request.Id, 
                request.Name,
                request.Description,
                request.Price,
                request.CategoryId)).Returns(product);
            Mock<IProductRepository> productRepository = RepositoryStub.CreateProductRepository();
            productRepository.Setup(o => o.Add(product));
            Mock<CreateProductValidator> createProductValidator = new Mock<CreateProductValidator>(productRepository.Object);
            createProductValidator.Setup(o => o.Validate(It.IsAny<ProductId>(), It.IsAny<ProductName>()));
            Mock<EmptyResponseConverter> emptyResponseConverter = new Mock<EmptyResponseConverter>();
            emptyResponseConverter.Setup(o => o.Convert());
            CreateProductUseCase useCase = new CreateProductUseCase(
                productFactory.Object,
                productRepository.Object,
                emptyResponseConverter.Object,
                createProductValidator.Object);

            useCase.Execute(request);

            productFactory.VerifyAll();
            productRepository.VerifyAll();
            emptyResponseConverter.VerifyAll();
            createProductValidator.VerifyAll();
        }
    }
}
