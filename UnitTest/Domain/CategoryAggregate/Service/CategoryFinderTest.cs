using BlockbusterApp.src.Domain.CategoryAggregate;
using BlockbusterApp.src.Domain.CategoryAggregate.Exception;
using BlockbusterApp.src.Domain.CategoryAggregate.Service;
using Moq;
using NUnit.Framework;
using System;
using System.ComponentModel.DataAnnotations;
using UnitTest.Domain.CategoryAggregate.Stub;
using UnitTest.Domain.Repository;

namespace UnitTest.Domain.CategoryAggregate.Service
{
    [TestFixture]
    public class CategoryFinderTest
    {

        [Test]
        public void ItShouldThrowExceptionFromCategoryNotFoundById()
        {
            CategoryFinder categoryFinder = GetCategoryFinder(null);

            var Exception = Assert.Throws<CategoryNotFoundException>(() => categoryFinder.FindOneById(CategoryIdStub.ByDefault()));

            Assert.Pass(Exception.Message, CategoryNotFoundException.FromId(CategoryIdStub.ByDefault()));
            Assert.IsInstanceOf<ValidationException>(Exception);
            Assert.AreEqual(Exception.Message, String.Format("Category with id {0} doesn't exists.", CategoryIdStub.ByDefault().GetValue()));
        }

        [Test]
        public void ItShouldFindCategoryByCode()
        {
            CategoryFinder categoryFinder = GetCategoryFinder(CategoryStub.ByDefault());

            var categoryfound = categoryFinder.FindOneById(CategoryIdStub.ByDefault());

            Assert.IsNotNull(categoryfound);
            Assert.IsInstanceOf<Category>(categoryfound);
        }

        private CategoryFinder GetCategoryFinder(Category category)
        {
            Mock<ICategoryRepository> categoryRepository = RepositoryStub.CreateCategoryRepository();
            categoryRepository.Setup(o => o.FindById(It.IsAny<CategoryId>())).Returns(category);
            CategoryFinder categoryFinder = new CategoryFinder(categoryRepository.Object);
            return categoryFinder;
        }
    }
}
