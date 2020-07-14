using BlockbusterApp.src.Domain.UserAggregate;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTest.Domain.UserAggregate
{
    [TestFixture]
    class UserUpdatedAtTest
    {

        [Test]
        public void ItShouldCreateNewUserCreatedAt()
        {
            DateTime dateTime = DateTime.Now;

            UserUpdatedAt userUpdatedAt = new UserUpdatedAt(dateTime);

            Assert.IsNotNull(userUpdatedAt);
            Assert.AreEqual(userUpdatedAt.GetValue(), dateTime);
        }
    }
}
