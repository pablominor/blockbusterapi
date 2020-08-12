using BlockbusterApp.src.Application.UseCase.User.FindById;
using NUnit.Framework;
using System;
using UnitTest.Domain.UserAggregate.Stub;

namespace UnitTest.Application.UseCase.User.FindById
{
    [TestFixture]
    public class FindUserByIdRequestTest
    {
        [Test]
        public void ItShouldReturnSameNumberOfValuesWhenRequestIsCorrect()
        {
            FindUserByIdRequest request = new FindUserByIdRequest();
            Type type = typeof(FindUserByIdRequest);
            int numberOfFields = type.GetProperties().Length;

            Assert.AreEqual(numberOfFields, 0);
        }
    }
}
