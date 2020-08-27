using BlockbusterApp.src.Application.UseCase.Category.Response;
using NUnit.Framework;
using UnitTest.Domain.CategoryAggregate.Stub;

namespace UnitTest.Application.UseCase.Category.Response
{
    [TestFixture]
    public class CategoryResponseConverterTest
    {
        [Test]
        public void ItShouldReturnCorrectResponse()
        {
            BlockbusterApp.src.Domain.CategoryAggregate.Category category = CategoryStub.ByDefault();
            CategoryResponseConverter converter = new CategoryResponseConverter();

            var res = converter.Convert(category);

            Assert.IsInstanceOf<CategoryResponse>(res);
            CategoryResponse response = res as CategoryResponse;
            Assert.AreEqual(response.Id, category.id.GetValue());
            Assert.AreEqual(response.Name, category.name.GetValue());
        }
    }
}
