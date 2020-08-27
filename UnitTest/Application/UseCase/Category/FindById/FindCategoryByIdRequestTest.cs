using BlockbusterApp.src.Application.UseCase.Category.FindById;
using NUnit.Framework;
using System;
using UnitTest.Domain.CategoryAggregate.Stub;

namespace UnitTest.Application.UseCase.Category.FindById
{
    [TestFixture]
    public class FindCategoryByIdRequestTest
    {
        [Test]
        public void ItShouldReturnSameNumberOfValuesWhenRequestIsCorrect()
        {
            FindCategoryByIdRequest request = new FindCategoryByIdRequest(
                CategoryIdStub.ByDefault().GetValue());
            Type type = typeof(FindCategoryByIdRequest);
            int numberOfFields = type.GetProperties().Length;

            Assert.AreEqual(numberOfFields, 1);
            Assert.AreEqual(request.Id, CategoryIdStub.ByDefault().GetValue());
        }
    }
}
