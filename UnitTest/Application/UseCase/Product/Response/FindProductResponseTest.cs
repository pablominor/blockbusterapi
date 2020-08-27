using BlockbusterApp.src.Application.UseCase.Product.Response;
using NUnit.Framework;
using UnitTest.Domain.ProductAggregate.Stub;

namespace UnitTest.Application.UseCase.Product.Response
{
    [TestFixture]
    public class FindProductResponseTest
    {
        [Test]
        public void ItShouldReturnCorrectResponse()
        {
            BlockbusterApp.src.Domain.ProductAggregate.Product product = ProductStub.ByDefault();

            FindProductResponse request = new FindProductResponse
            {
                Id = product.id.GetValue(),
                Name = product.name.GetValue(),
                Description = product.description.GetValue(),
                Price = product.price.GetValue(),
                CategoryId = product.categoryId.GetValue()
            };

            Assert.AreEqual(request.Id, product.id.GetValue());
            Assert.AreEqual(request.Name, product.name.GetValue());
            Assert.AreEqual(request.Description, product.description.GetValue());
            Assert.AreEqual(request.Price, product.price.GetValue());
            Assert.AreEqual(request.CategoryId, product.categoryId.GetValue());
        }
    }
}
