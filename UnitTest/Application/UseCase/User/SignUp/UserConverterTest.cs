using BlockbusterApp.src.Application.UseCase.User.SignUP;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitTest.Application.UseCase.User.SignUp
{
    [TestFixture]
    class UserConverterTest
    {

        [Test]
        public void ItShouldReturnSignUpUserResponse()
        {
            UserConverter userConverter = new UserConverter();

            var response = userConverter.Convert();
            
            Assert.IsInstanceOf<SignUpUserResponse>(response);            
        }
    }
}
