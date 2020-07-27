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
    class UserIdTest
    {

        [Test]
        public void ItShouldThrowExceptionFromEmpty()
        {
            string invalidEmptyId = "";

            var Exception = Assert.Throws<InvalidAttributeException>(() => new UserId(invalidEmptyId));

            Assert.Pass(Exception.Message, InvalidAttributeException.FromEmpty("UUID"));
            Assert.IsInstanceOf<InvalidUUIDException>(Exception);
        }

        [Test]
        public void ItShouldThrowExceptionFromInvalidFormat()
        {
            string invalidId = "123456789";

            var Exception = Assert.Throws<InvalidAttributeException>(() => new UserId(invalidId));

            Assert.Pass(Exception.Message, InvalidAttributeException.FromValue("UUID",invalidId));
            Assert.IsInstanceOf<InvalidUUIDException>(Exception);
        }

        [Test]
        public void ItShouldCreateNewUserId()
        {
            string id = "a742aea9-1923-45bd-903e-b0210436d6c2";

            UserId userId = new UserId(id);

            Assert.IsNotNull(userId);
            Assert.AreEqual(userId.GetValue(), id);
        }

        [Test]
        public void ItShouldReturnTrueWhenTwoUserIdAreEqual()
        {
            string id = "a742aea9-1923-45bd-903e-b0210436d6c2";

            UserId userId1 = new UserId(id);
            UserId userId2 = new UserId(id);

            Assert.IsTrue(userId1.Equals(userId2));            
        }
    }
}
