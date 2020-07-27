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
    class UserLastNameTest
    {

        [Test]
        public void ItShouldThrowExceptionFromMaxLength()
        {
            string invalidLastName = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";

            var Exception = Assert.Throws<InvalidAttributeException>(() => new UserLastName(invalidLastName));

            Assert.Pass(Exception.Message, InvalidAttributeException.FromMaxLength("last name", UserLastName.MAX_LENGTH));
            Assert.IsInstanceOf<InvalidUserAttributeException>(Exception);
        }

        [Test]
        public void ItShouldThrowExceptionFromMinLength()
        {
            string invalidLastName = "aa";

            var Exception = Assert.Throws<InvalidAttributeException>(() => new UserLastName(invalidLastName));

            Assert.Pass(Exception.Message, InvalidAttributeException.FromMinLength("last name", UserLastName.MIN_LENGTH));
            Assert.IsInstanceOf<InvalidUserAttributeException>(Exception);
        }

        [Test]
        public void ItShouldCreateNewUserLastName()
        {
            string name = "BlockbusterApp";

            UserLastName userLastName = new UserLastName(name);

            Assert.IsNotNull(userLastName);
            Assert.AreEqual(userLastName.GetValue(), name);
        }

        [Test]
        public void ItShouldReturnTrueWhenTwoUserLastNameAreEqual()
        {
            string name = "BlockbusterApp";

            UserLastName userLastName1 = new UserLastName(name);
            UserLastName userLastName2 = new UserLastName(name);

            Assert.IsTrue(userLastName1.Equals(userLastName2));            
        }
    }
}
