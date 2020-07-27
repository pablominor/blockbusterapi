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
    class UserEmailTest
    {

        [Test]
        public void ItShouldThrowExceptionFromInvalidFormat()
        {
            string invalidEmail = "blocbusterprueba";

            var Exception = Assert.Throws<InvalidAttributeException>(() => new UserEmail(invalidEmail));

            Assert.Pass(Exception.Message, InvalidAttributeException.FromValue("email", invalidEmail));
            Assert.IsInstanceOf<InvalidUserAttributeException>(Exception);
        }

        [Test]
        public void ItShouldCreateNewUserEmail()
        {
            string email = "blocbusterprueba@gmail.com";

            UserEmail userEmail = new UserEmail(email);

            Assert.IsNotNull(userEmail);
            Assert.AreEqual(userEmail.GetValue(), email);
        }

        [Test]
        public void ItShouldReturnTrueWhenTwoUserEmailAreEqual()
        {
            string email = "blocbusterprueba@gmail.com";

            UserEmail userEmail1 = new UserEmail(email);
            UserEmail userEmail2 = new UserEmail(email);

            Assert.IsTrue(userEmail1.Equals(userEmail2));            
        }
    }
}
