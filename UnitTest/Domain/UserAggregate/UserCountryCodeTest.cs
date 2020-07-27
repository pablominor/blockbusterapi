using BlockbusterApp.src.Domain.UserAggregate;
using NUnit.Framework;

namespace UnitTest.Domain.UserAggregate
{
    [TestFixture]
    class UserCountryCodeTest
    {
           
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
