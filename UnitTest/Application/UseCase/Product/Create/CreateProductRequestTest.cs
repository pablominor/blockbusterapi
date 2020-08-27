using BlockbusterApp.src.Application.UseCase.Product.Create;
using NUnit.Framework;
using System;
using UnitTest.Domain.ProductAggregate.Stub;

namespace UnitTest.Application.UseCase.Product.Create
{
    [TestFixture]
    public class CreateProductRequestTest
    {
        [Test]
        public void ItShouldReturnSameNumberOfValuesWhenRequestIsCorrect()
        {
            CreateProductRequest request = new CreateProductRequest(
                ProductIdStub.ByDefault().GetValue(),
                ProductNameStub.ByDefault().GetValue(),
                ProductDescriptionStub.ByDefault().GetValue(),
                ProductPriceStub.ByDefault().GetValue(),
                ProductCategoryIdStub.ByDefault().GetValue());
            Type type = typeof(CreateProductRequest);
            int numberOfFields = type.GetProperties().Length;

            Assert.AreEqual(numberOfFields, 5);
            Assert.AreEqual(request.Id, ProductIdStub.ByDefault().GetValue());
            Assert.AreEqual(request.Name, ProductNameStub.ByDefault().GetValue());
            Assert.AreEqual(request.Description, ProductDescriptionStub.ByDefault().GetValue());
            Assert.AreEqual(request.Price, ProductPriceStub.ByDefault().GetValue());
            Assert.AreEqual(request.CategoryId, ProductCategoryIdStub.ByDefault().GetValue());
        }
    }
}
