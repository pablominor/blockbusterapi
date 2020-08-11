using BlockbusterApp.src.Application.UseCase.User.FindByEmalAndPassword;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using UnitTest.Domain.UserAggregate.Stub;

namespace UnitTest.Application.UseCase.User.FindByEmailAndPassword
{
    [TestFixture]
    public class FindUserByEmailAndPasswordRequestTest
    {
        [Test]
        public void ItShouldReturnSameNumberOfValuesWhenRequestIsCorrect()
        {
            FindUserByEmailAndPasswordRequest request = new FindUserByEmailAndPasswordRequest(
                UserEmailStub.ByDefault().GetValue(),
                UserPasswordStub.ByDefault().GetValue());
            Type type = typeof(FindUserByEmailAndPasswordRequest);
            int numberOfFields = type.GetProperties().Length;

            Assert.AreEqual(numberOfFields, 2);
            Assert.AreEqual(request.Email, UserEmailStub.ByDefault().GetValue());
            Assert.AreEqual(request.Password, UserPasswordStub.ByDefault().GetValue());

        }

    }
}
