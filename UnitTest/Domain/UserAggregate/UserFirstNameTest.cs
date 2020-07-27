using BlockbusterApp.src.Domain.UserAggregate;
using BlockbusterApp.src.Domain.UserAggregate.Exception;
using BlockbusterApp.src.Shared.Domain.Exception;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTest.Domain.UserAggregate
{
    [TestFixture]
    class UserFirstNameTest
    {

        [Test]
        public void ItShouldThrowExceptionFromMaxLength()
        {
            string invalidFirstName = "aaaaaaaaaaaaaaaa";

            var Exception = Assert.Throws<InvalidAttributeException>(() => new UserFirstName(invalidFirstName));

            Assert.Pass(Exception.Message, InvalidAttributeException.FromMaxLength("first name", UserFirstName.MAX_LENGTH));
            Assert.IsInstanceOf<InvalidUserAttributeException>(Exception);
        }

        [Test]
        public void ItShouldThrowExceptionFromMinLength()
        {
            string invalidFirstName = "aa";

            var Exception = Assert.Throws<InvalidAttributeException>(() => new UserFirstName(invalidFirstName));

            Assert.Pass(Exception.Message, InvalidAttributeException.FromMinLength("first name", UserFirstName.MIN_LENGTH));
            Assert.IsInstanceOf<InvalidUserAttributeException>(Exception);
        }

        [Test]
        public void ItShouldCreateNewUserFirstName()
        {
            string name = "BlockbusterApp";

            UserFirstName userFirstName = new UserFirstName(name);

            Assert.IsNotNull(userFirstName);
            Assert.AreEqual(userFirstName.GetValue(), name);
        }

        [Test]
        public void ItShouldReturnTrueWhenTwoUserFirstNameAreEqual()
        {
            string name = "BlockbusterApp";

            UserFirstName userFirstName1 = new UserFirstName(name);
            UserFirstName userFirstName2 = new UserFirstName(name);

            Assert.IsTrue(userFirstName1.Equals(userFirstName2));            
        }
    }
}
