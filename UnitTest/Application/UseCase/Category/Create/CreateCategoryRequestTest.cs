using BlockbusterApp.src.Application.UseCase.Category.Create;
using NUnit.Framework;
using System;
using UnitTest.Domain.CategoryAggregate.Stub;

namespace UnitTest.Application.UseCase.Category.Create
{
    [TestFixture]
    public class CreateCategoryRequestTest
    {
        [Test]
        public void ItShouldReturnSameNumberOfValuesWhenRequestIsCorrect()
        {
            CreateCategoryRequest request = new CreateCategoryRequest(
                CategoryIdStub.ByDefault().GetValue(),
                CategoryNameStub.ByDefault().GetValue());
            Type type = typeof(CreateCategoryRequest);
            int numberOfFields = type.GetProperties().Length;

            Assert.AreEqual(numberOfFields, 2);
            Assert.AreEqual(request.Id, CategoryIdStub.ByDefault().GetValue());
            Assert.AreEqual(request.Name, CategoryNameStub.ByDefault().GetValue());
        }
    }
}
