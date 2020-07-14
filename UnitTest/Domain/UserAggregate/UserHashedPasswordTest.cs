using BlockbusterApp.src.Domain.UserAggregate;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTest.Domain.UserAggregate
{
    [TestFixture]
    class UserHashedPasswordTest
    {

        [Test]
        public void ItShouldCreateNewUserHashedPassword()
        {
            string password = "qRtf2ss*";

            UserHashedPassword userHashedPassword = new UserHashedPassword(password);

            Assert.IsNotNull(userHashedPassword);
            Assert.AreEqual(userHashedPassword.GetValue(), password);
        }

        [Test]
        public void ItShouldReturnTrueWhenTwoUserHashedPasswordAreEquals()
        {
            string password = "qRtf2ss*";

            UserHashedPassword userHashedPassword1 = new UserHashedPassword(password);
            UserHashedPassword userHashedPassword2 = new UserHashedPassword(password);

            Assert.IsTrue(userHashedPassword1.Equals(userHashedPassword2));            
        }
    }
}
