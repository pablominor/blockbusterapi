using BlockbusterApp.src.Application.UseCase.Product.Response;
using NUnit.Framework;
using UnitTest.Domain.ProductAggregate.Stub;

namespace UnitTest.Application.UseCase.Product.Response
{
    [TestFixture]
    public class FindProductResponseConverterTest
    {
        [Test]
        public void ItShouldReturnCorrectResponse()
        {
            BlockbusterApp.src.Domain.ProductAggregate.Product product = ProductStub.ByDefault();
            FindProductResponseConverter converter = new FindProductResponseConverter();

            var res = converter.Convert(product);

            Assert.IsInstanceOf<FindProductResponse>(res);
            FindProductResponse response = res as FindProductResponse;
            Assert.AreEqual(response.Id, product.id.GetValue());
            Assert.AreEqual(response.Name, product.name.GetValue());
            Assert.AreEqual(response.Description, product.description.GetValue());
            Assert.AreEqual(response.Price, product.price.GetValue());
            Assert.AreEqual(response.CategoryId, product.categoryId.GetValue());
        }
    }
}
