using BlockbusterApp.src.Domain.CategoryAggregate;
using BlockbusterApp.src.Domain.CategoryAggregate.Exception;
using BlockbusterApp.src.Domain.CategoryAggregate.Service;
using BlockbusterApp.src.Shared.Domain.Exception;
using Moq;
using NUnit.Framework;
using System;
using UnitTest.Domain.CategoryAggregate.Stub;
using UnitTest.Domain.Repository;

namespace UnitTest.Domain.CategoryAggregate.Service
{
    [TestFixture]
    public class CreateCategoryValidatorTest
    {

        private string categoryId = "3debbe23-f331-40b9-95dc-43148c705fc8";
        private string categoryName = "New Category";

        [Test]
        public void ItShouldThrowExceptionWhenFindCategoryWithSameId()
        {
            CreateCategoryValidator createCategoryValidator = GetCreateCategoryValidator();

            var Exception = Assert.Throws<CategoryFoundException>(() => createCategoryValidator.Validate(CategoryIdStub.ByDefault(), CategoryNameStub.ByDefault()));

            Assert.Pass(Exception.Message, CategoryFoundException.FromId(CategoryIdStub.ByDefault()));
            Assert.IsInstanceOf<ValidationException>(Exception);
            Assert.AreEqual(Exception.Message, String.Format("Category is already register with the id {0}.", CategoryIdStub.ByDefault().GetValue()));
        }

        [Test]
        public void ItShouldThrowExceptionWhenFindCategoryWithSameName()
        {
            CreateCategoryValidator createCategoryValidator = GetCreateCategoryValidator();

            var Exception = Assert.Throws<CategoryFoundException>(() => createCategoryValidator.Validate(CategoryIdStub.Create(categoryId), CategoryNameStub.ByDefault()));

            Assert.Pass(Exception.Message, CategoryFoundException.FromName(CategoryNameStub.ByDefault()));
            Assert.IsInstanceOf<ValidationException>(Exception);
            Assert.AreEqual(Exception.Message, String.Format("Category is already register with name id {0}.", CategoryNameStub.ByDefault().GetValue()));
        }

        [Test]
        public void ItShouldValidateAnCallCollaborators()
        {
            Mock<ICategoryRepository> categoryRepository = GetMockedCategoryRepository();
            CreateCategoryValidator createCategoryValidator = new CreateCategoryValidator(categoryRepository.Object);

            createCategoryValidator.Validate(CategoryIdStub.Create(categoryId), CategoryNameStub.Create(categoryName));

            categoryRepository.VerifyAll();
        }

        private CreateCategoryValidator GetCreateCategoryValidator()
        {
            Mock<ICategoryRepository> categoryRepository = GetMockedCategoryRepository();
            CreateCategoryValidator createCategoryValidator = new CreateCategoryValidator(categoryRepository.Object);

            return createCategoryValidator;
        }

        private Mock<ICategoryRepository> GetMockedCategoryRepository()
        {
            Mock<ICategoryRepository> categoryRepository = RepositoryStub.CreateCategoryRepository();
            categoryRepository.Setup(o => o.FindByIdOrName(It.IsAny<CategoryId>(), It.IsAny<CategoryName>())).Returns(CategoryStub.ByDefault());
            return categoryRepository;
        }
    }
}
