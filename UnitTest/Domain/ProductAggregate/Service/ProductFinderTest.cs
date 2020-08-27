using BlockbusterApp.src.Domain.ProductAggregate;
using BlockbusterApp.src.Domain.ProductAggregate.Exception;
using BlockbusterApp.src.Domain.ProductAggregate.Service;
using Moq;
using NUnit.Framework;
using System;
using System.ComponentModel.DataAnnotations;
using UnitTest.Domain.ProductAggregate.Stub;
using UnitTest.Domain.Repository;

namespace UnitTest.Domain.ProductAggregate.Service
{
    [TestFixture]
    public class ProductFinderTest
    {

        [Test]
        public void ItShouldThrowExceptionFromProductNotFoundById()
        {
            ProductFinder productFinder = GetProductFinder(null);

            var Exception = Assert.Throws<ProductNotFoundException>(() => productFinder.FindOneById(ProductIdStub.ByDefault()));

            Assert.Pass(Exception.Message, ProductNotFoundException.FromId(ProductIdStub.ByDefault()));
            Assert.IsInstanceOf<ValidationException>(Exception);
            Assert.AreEqual(Exception.Message, String.Format("Product with id {0} doesn't exists.", ProductIdStub.ByDefault().GetValue()));
        }

        [Test]
        public void ItShouldFindProductByCode()
        {
            ProductFinder productFinder = GetProductFinder(ProductStub.ByDefault());

            var productfound = productFinder.FindOneById(ProductIdStub.ByDefault());

            Assert.IsNotNull(productfound);
            Assert.IsInstanceOf<Product>(productfound);
        }


        private ProductFinder GetProductFinder(Product product)
        {
            Mock<IProductRepository> productRepository = RepositoryStub.CreateProductRepository();
            productRepository.Setup(o => o.FindById(It.IsAny<ProductId>())).Returns(product);
            ProductFinder productFinder = new ProductFinder(productRepository.Object);
            return productFinder;
        }
    }
}
