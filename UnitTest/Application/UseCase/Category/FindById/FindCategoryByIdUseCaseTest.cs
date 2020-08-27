using BlockbusterApp.src.Application.UseCase.Category.FindById;
using BlockbusterApp.src.Application.UseCase.Category.Response;
using BlockbusterApp.src.Domain.CategoryAggregate;
using BlockbusterApp.src.Domain.CategoryAggregate.Service;
using Moq;
using NUnit.Framework;
using UnitTest.Domain.CategoryAggregate.Stub;

namespace UnitTest.Application.UseCase.Category.FindById
{
    [TestFixture]
    public class FindCategoryByIdUseCaseTest
    {
        [Test]
        public void ItShouldCallCollaborators()
        {
            FindCategoryByIdRequest request = FindCategoryByIdRequestStub.ByDefault();
            BlockbusterApp.src.Domain.CategoryAggregate.Category category = CategoryStub.ByDefault();
            Mock<CategoryFinder> categoryFinder = CategoryFinderStub.ByDefault();
            categoryFinder.Setup(o => o.FindOneById(It.IsAny<CategoryId>())).Returns(category);
            Mock<CategoryResponseConverter> converter = new Mock<CategoryResponseConverter>();
            converter.Setup(o => o.Convert(category));
            FindCategoryByIdUseCase useCase = new FindCategoryByIdUseCase(converter.Object, categoryFinder.Object);

            useCase.Execute(request);
            categoryFinder.VerifyAll();
            converter.VerifyAll();
        }
    }
}
