using BlockbusterApp.src.Application.UseCase.User.SignUP;
using NUnit.Framework;
using System;
using UnitTest.Domain.UserAggregate.Stub;

namespace UnitTest.Application.UseCase.User.SignUp
{
    [TestFixture]
    public class SignUpUserRequestTest
    {

        [Test]
        public void ItShouldReturnSameNumberOfValuesWhenRequestIsCorrect()
        {
            SignUpUserRequest request = new SignUpUserRequest(
                UserIdStub.ByDefault().GetValue(),
                UserEmailStub.ByDefault().GetValue(),
                UserPasswordStub.ByDefault().GetValue(),
                UserPasswordStub.ByDefault().GetValue(),
                UserFirstNameStub.ByDefault().GetValue(),
                UserLastNameStub.ByDefault().GetValue(),
                UserRoleStub.CreateLikeUser().GetValue(),
                UserCountryCodeStub.ByDefault().GetValue()
                ) ;
            Type type = typeof(SignUpUserRequest);
            int numberOfFields = type.GetProperties().Length;

            Assert.AreEqual(numberOfFields, 8);
            Assert.AreEqual(request.Id, UserIdStub.ByDefault().GetValue());
            Assert.AreEqual(request.Email, UserEmailStub.ByDefault().GetValue());
            Assert.AreEqual(request.Password, UserPasswordStub.ByDefault().GetValue());
            Assert.AreEqual(request.RepeatPassword, UserPasswordStub.ByDefault().GetValue());
            Assert.AreEqual(request.FirstName, UserFirstNameStub.ByDefault().GetValue());
            Assert.AreEqual(request.LastName, UserLastNameStub.ByDefault().GetValue());
            Assert.AreEqual(request.Role, UserRoleStub.CreateLikeUser().GetValue());
            Assert.AreEqual(request.CountryCode, UserCountryCodeStub.ByDefault().GetValue());
        }
    }
}
