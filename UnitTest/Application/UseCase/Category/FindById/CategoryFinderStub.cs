using BlockbusterApp.src.Domain.CategoryAggregate;
using BlockbusterApp.src.Domain.CategoryAggregate.Service;
using Moq;
using UnitTest.Domain.Repository;

namespace UnitTest.Application.UseCase.Category.FindById
{
    public class CategoryFinderStub
    {
        public static Mock<CategoryFinder> ByDefault()
        {
            Mock<ICategoryRepository> categoryRepository = RepositoryStub.CreateCategoryRepository();
            Mock<CategoryFinder> categoryFinder = new Mock<CategoryFinder>(categoryRepository.Object);
            return categoryFinder;
        }
    }
}
