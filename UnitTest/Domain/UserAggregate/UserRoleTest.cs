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
    class UserRoleTest
    {

        [Test]
        public void ItShouldThrowExceptionFromInvalidValue()
        {
            string invalidRole = "usuario";

            var Exception = Assert.Throws<InvalidAttributeException>(() => new UserRole(invalidRole));

            Assert.Pass(Exception.Message, InvalidAttributeException.FromText("This role is not correct"));
            Assert.IsInstanceOf<InvalidUserAttributeException>(Exception);
        }


        [Test]
        [TestCase("Admin")]
        [TestCase("User")]
        public void ItShouldCreateNewUserRole(string role)
        {           
            UserRole UserRole = new UserRole(role);

            Assert.IsNotNull(UserRole);
            Assert.AreEqual(UserRole.GetValue(), role);
        }

        [Test]
        public void ItShouldReturnTrueWhenTwoUserRoleAreEqual()
        {
            string role = "Admin";

            UserRole UserRole1 = new UserRole(role);
            UserRole UserRole2 = new UserRole(role);

            Assert.IsTrue(UserRole1.Equals(UserRole2));            
        }
    }
}
