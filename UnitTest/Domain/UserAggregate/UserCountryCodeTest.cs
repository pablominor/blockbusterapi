using BlockbusterApp.src.Domain.UserAggregate;
using BlockbusterApp.src.Domain.UserAggregate.Exception;
using BlockbusterApp.src.Shared.Domain;
using BlockbusterApp.src.Shared.Domain.Exception;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTest.Domain.UserAggregate
{
    [TestFixture]
    class UserCountryCodeTest
    {
        private string AttributeValue;

        [SetUp]
        public void Init()
        {
            this.AttributeValue = "country code";
        }

        [Test]
        public void ItShouldThrowExceptionFromMaxLength()
        {
            string invalidCountryCode = "ESP";

            var Exception = Assert.Throws<InvalidAttributeException>(() => new UserCountryCode(invalidCountryCode));
            Assert.Pass(Exception.Message, InvalidAttributeException.FromMaxLength(AttributeValue, CountryCode.MAX_LENGTH));
            Assert.IsInstanceOf<InvalidCountryCodeException>(Exception);
        }

        [Test]
        public void ItShouldThrowExceptionFromMinLength()
        {
            string invalidCountryCode = "E";

            var Exception = Assert.Throws<InvalidAttributeException>(() => new UserCountryCode(invalidCountryCode));
            Assert.Pass(Exception.Message, InvalidAttributeException.FromMinLength(AttributeValue,CountryCode.MIN_LENGTH));
            Assert.IsInstanceOf<InvalidCountryCodeException>(Exception);
        }

        [Test]
        public void ItShouldThrowExceptionFromEmpty()
        {
            string invalidCountryCode = "";

            var Exception = Assert.Throws<InvalidAttributeException>(() => new UserCountryCode(invalidCountryCode));
            Assert.Pass(Exception.Message, InvalidAttributeException.FromEmpty(AttributeValue));
            Assert.IsInstanceOf<InvalidCountryCodeException>(Exception);
        }

        [Test]
        public void ItShouldCreateNewUserCountryCode()
        {
            string countryCode = "ES";

            UserCountryCode UserCountryCode = new UserCountryCode(countryCode);

            Assert.IsNotNull(UserCountryCode);
            Assert.AreEqual(UserCountryCode.GetValue(), countryCode);
        }

        [Test]
        public void ItShouldReturnTrueWhenTwoUserCountryCodeAreEqual()
        {
            string countryCode = "ES";

            UserCountryCode UserCountryCode1 = new UserCountryCode(countryCode);
            UserCountryCode UserCountryCode2 = new UserCountryCode(countryCode);

            Assert.IsTrue(UserCountryCode1.Equals(UserCountryCode2));            
        }
    }
}
