using BlockbusterApp.src.Domain.UserAggregate;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTest.Domain.UserAggregate
{
    [TestFixture]
    class UserCreatedAtTest
    {

        [Test]
        public void ItShouldCreateNewUserCreatedAt()
        {
            DateTime dateTime = DateTime.Now;

            UserCreatedAt userCreatedAt = new UserCreatedAt(dateTime);

            Assert.IsNotNull(userCreatedAt);
            Assert.AreEqual(userCreatedAt.GetValue(), dateTime);
        }
    }
}
