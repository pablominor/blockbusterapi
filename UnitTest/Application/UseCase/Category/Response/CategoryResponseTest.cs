using BlockbusterApp.src.Application.UseCase.Category.Response;
using NUnit.Framework;
using UnitTest.Domain.CategoryAggregate.Stub;

namespace UnitTest.Application.UseCase.Category.Response
{
    [TestFixture]
    public class CategoryResponseTest
    {

        [Test]
        public void ItShouldReturnCorrectResponse()
        {
            BlockbusterApp.src.Domain.CategoryAggregate.Category category = CategoryStub.ByDefault();

            CategoryResponse request = new CategoryResponse
            {
                Id = category.id.GetValue(),
                Name = category.name.GetValue()
            };

            Assert.AreEqual(request.Id, category.id.GetValue());
            Assert.AreEqual(request.Name, category.name.GetValue());
        }
    }
}
