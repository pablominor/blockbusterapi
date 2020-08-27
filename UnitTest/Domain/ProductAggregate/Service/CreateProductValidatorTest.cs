using BlockbusterApp.src.Domain.ProductAggregate;
using BlockbusterApp.src.Domain.ProductAggregate.Exception;
using BlockbusterApp.src.Domain.ProductAggregate.Service;
using BlockbusterApp.src.Shared.Domain.Exception;
using Moq;
using NUnit.Framework;
using System;
using UnitTest.Domain.ProductAggregate.Stub;
using UnitTest.Domain.Repository;

namespace UnitTest.Domain.ProductAggregate.Service
{
    [TestFixture]
    public class CreateProductValidatorTest
    {
        private string productId = "3debbe23-f331-40b9-95dc-43148c705fc8";
        private string productName = "New Product";

        [Test]
        public void ItShouldThrowExceptionWhenFindProductWithSameId()
        {
            CreateProductValidator createProductValidator = GetCreateProductValidator();

            var Exception = Assert.Throws<ProductFoundException>(() => createProductValidator.Validate(ProductIdStub.ByDefault(), ProductNameStub.ByDefault()));

            Assert.Pass(Exception.Message, ProductFoundException.FromId(ProductIdStub.ByDefault()));
            Assert.IsInstanceOf<ValidationException>(Exception);
            Assert.AreEqual(Exception.Message, String.Format("Product is already register with the id {0}.", ProductIdStub.ByDefault().GetValue()));
        }

        [Test]
        public void ItShouldThrowExceptionWhenFindProductWithSameName()
        {
            CreateProductValidator createProductValidator = GetCreateProductValidator();

            var Exception = Assert.Throws<ProductFoundException>(() => createProductValidator.Validate(ProductIdStub.Create(productId), ProductNameStub.ByDefault()));

            Assert.Pass(Exception.Message, ProductFoundException.FromName(ProductNameStub.ByDefault()));
            Assert.IsInstanceOf<ValidationException>(Exception);
            Assert.AreEqual(Exception.Message, String.Format("Product is already register with name id {0}.", ProductNameStub.ByDefault().GetValue()));
        }

        [Test]
        public void ItShouldValidateAnCallCollaborators()
        {
            Mock<IProductRepository> productRepository = GetMockedProductRepository();
            CreateProductValidator createProductValidator = new CreateProductValidator(productRepository.Object);

            createProductValidator.Validate(ProductIdStub.Create(productId), ProductNameStub.Create(productName));

            productRepository.VerifyAll();
        }

        private CreateProductValidator GetCreateProductValidator()
        {
            Mock<IProductRepository> productRepository = GetMockedProductRepository();
            CreateProductValidator createProductValidator = new CreateProductValidator(productRepository.Object);

            return createProductValidator;
        }

        private Mock<IProductRepository> GetMockedProductRepository()
        {
            Mock<IProductRepository> productRepository = RepositoryStub.CreateProductRepository();
            productRepository.Setup(o => o.FindByIdOrName(It.IsAny<ProductId>(), It.IsAny<ProductName>())).Returns(ProductStub.ByDefault());
            return productRepository;
        }
    }
}
