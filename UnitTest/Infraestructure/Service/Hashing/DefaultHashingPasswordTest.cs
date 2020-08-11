using BlockbusterApp.src.Domain.UserAggregate;
using BlockbusterApp.src.Infraestructure.Service.Hashing;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using UnitTest.Domain.UserAggregate.Stub;

namespace UnitTest.Infraestructure.Service.Hashing
{
    [TestFixture]
    class DefaultHashingPasswordTest
    {

        [Test]
        public void ItShouldReturnTrueWhenTwoHashedPasswordsAreEqual()
        {

            DefaultHashing defaultHashing = new DefaultHashing();
            
            UserHashedPassword password1 = defaultHashing.Hash(UserPasswordStub.ByDefault().GetValue());
            UserHashedPassword password2 = defaultHashing.Hash(UserPasswordStub.ByDefault().GetValue());

            Assert.IsTrue(password1.Equals(password2));
        }
    }
}
