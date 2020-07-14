using BlockbusterApp.src.Domain.UserAggregate;
using BlockbusterApp.src.Domain.UserAggregate.Exception;
using BlockbusterApp.src.Shared.Domain.Exception;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using UnitTest.Stub.UserAggregate;

namespace UnitTest.Domain.UserAggregate
{
    [TestFixture]
    class UserPasswordTest
    {

        [Test]
        [TestCase("aastreas")]
        [TestCase("AsssAaaa")]
        [TestCase("99aaaaaaaaaa")]
        [TestCase("99AAAAAAAAAAAA")]
        public void ItShouldThrowExceptionWhenFormatIsNotValid(string password)
        {
                       
            var Exception = Assert.Throws<InvalidAttributeException>(() => new UserPassword(password));
            Assert.Pass(Exception.Message, InvalidAttributeException.FromValue("password", password));
            Assert.IsInstanceOf<InvalidUserAttributeException>(Exception);
        }

        [Test]
        [TestCase("CraftCode1", "CraftCode2")]
        [TestCase("TresEas1", "CraftCode2")]
        [TestCase("Blockbuster1", "BlockBuster")]
        public void ItShouldReturnExceptionWhenPasswordsAreNotEquals(string password,string repeatPassword)
        {

            var Exception = Assert.Throws<InvalidAttributeException>(() => UserPassword.Validate(password, repeatPassword));
            Assert.Pass(Exception.Message, InvalidAttributeException.FromText("Password must be equal than repeat password"));
            Assert.IsInstanceOf<InvalidUserAttributeException>(Exception);                  
        }

        [Test]
        public void ItShouldCreateNewUserPassword()
        {

            UserPassword userPassword = new UserPassword(UserPasswordStub.ByDefault().GetValue());

            Assert.IsNotNull(userPassword);
            Assert.AreEqual(userPassword.GetValue(), UserPasswordStub.ByDefault().GetValue());
        }

        [Test]
        public void ItShouldReturnTrueWhenTwoUserPasswordAreEqual()
        {

            UserPassword userPassword1 = new UserPassword(UserPasswordStub.ByDefault().GetValue());
            UserPassword userPassword2 = new UserPassword(UserPasswordStub.ByDefault().GetValue());

            Assert.IsTrue(userPassword1.Equals(userPassword2));
        }
    }
}
