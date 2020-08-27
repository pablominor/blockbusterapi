using BlockbusterApp.src.Application.UseCase.Category.Create;
using BlockbusterApp.src.Domain.CategoryAggregate;
using BlockbusterApp.src.Domain.CategoryAggregate.Service;
using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using Moq;
using NUnit.Framework;
using UnitTest.Domain.CategoryAggregate.Stub;
using UnitTest.Domain.Repository;

namespace UnitTest.Application.UseCase.Category.Create
{
    [TestFixture]
    public class CreateCategoryUseCaseStub
    {
        [Test]
        public void ItShouldCallCollaborators()
        {
            CreateCategoryRequest request = CreateCategoryRequestStub.ByDefault();
            BlockbusterApp.src.Domain.CategoryAggregate.Category category = CategoryStub.ByDefault();
            Mock<ICategoryFactory> categoryFactory = new Mock<ICategoryFactory>();
            categoryFactory.Setup(o => o.Create(request.Id,request.Name)).Returns(category);
            Mock<ICategoryRepository> categoryRepository = RepositoryStub.CreateCategoryRepository();
            categoryRepository.Setup(o => o.Add(category));
            Mock<CreateCategoryValidator> createCategoryValidator = new Mock<CreateCategoryValidator>(categoryRepository.Object);
            createCategoryValidator.Setup(o => o.Validate(It.IsAny<CategoryId>(),It.IsAny<CategoryName>()));
            Mock<EmptyResponseConverter> emptyResponseConverter = new Mock<EmptyResponseConverter>();
            emptyResponseConverter.Setup(o => o.Convert());
            CreateCategoryUseCase useCase = new CreateCategoryUseCase(
                categoryFactory.Object,
                categoryRepository.Object,
                emptyResponseConverter.Object,
                createCategoryValidator.Object);

            useCase.Execute(request);

            categoryFactory.VerifyAll();
            categoryRepository.VerifyAll();
            emptyResponseConverter.VerifyAll();
            createCategoryValidator.VerifyAll();
        }
    }
}
