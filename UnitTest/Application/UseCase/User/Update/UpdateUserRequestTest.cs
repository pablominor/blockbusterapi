using BlockbusterApp.src.Application.UseCase.User.Update;
using NUnit.Framework;
using System;
using UnitTest.Domain.UserAggregate.Stub;

namespace UnitTest.Application.UseCase.User.Update
{
    [TestFixture]
    public class UpdateUserRequestTest
    {

        [Test]
        public void ItShouldReturnSameNumberOfValuesWhenRequestIsCorrect()
        {
            UpdateUserRequest request = new UpdateUserRequest(                
                UserFirstNameStub.ByDefault().GetValue(),
                UserLastNameStub.ByDefault().GetValue(),
                UserPasswordStub.ByDefault().GetValue()
                );
            Type type = typeof(UpdateUserRequest);
            int numberOfFields = type.GetProperties().Length;

            Assert.AreEqual(numberOfFields, 4);
            Assert.AreEqual(request.Password, UserPasswordStub.ByDefault().GetValue());
            Assert.AreEqual(request.FirstName, UserFirstNameStub.ByDefault().GetValue());
            Assert.AreEqual(request.LastName, UserLastNameStub.ByDefault().GetValue());
        }
    }
}
