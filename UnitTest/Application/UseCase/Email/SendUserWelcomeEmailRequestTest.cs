using BlockbusterApp.src.Application.UseCase.Email.SendUserWelcome;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using UnitTest.Domain.UserAggregate.Stub;

namespace UnitTest.Application.UseCase.Email
{
    [TestFixture]
    public class SendUserWelcomeEmailRequestTest
    {

        [Test]
        public void ItShouldReturnSameNumberOfValuesWhenRequestIsCorrect()
        {
            SendUserWelcomeEmailRequest request = new SendUserWelcomeEmailRequest(
                UserEmailStub.ByDefault().GetValue(),
                UserFirstNameStub.ByDefault().GetValue(),
                UserLastNameStub.ByDefault().GetValue());

            Type type = typeof(SendUserWelcomeEmailRequest);
            int numberOfFields = type.GetProperties().Length;

            Assert.AreEqual(numberOfFields, 3);
            Assert.AreEqual(request.Email, UserEmailStub.ByDefault().GetValue());
            Assert.AreEqual(request.FirstName, UserFirstNameStub.ByDefault().GetValue());
            Assert.AreEqual(request.LastName, UserLastNameStub.ByDefault().GetValue());
        }
    }
}
