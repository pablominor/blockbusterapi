using BlockbusterApp.src.Domain.CountryAggregate;
using NUnit.Framework;

namespace UnitTest.Domain.CountryAggregate
{
    [TestFixture]
    public class CountryCodeTest
    {
        private string code;

        [SetUp]
        public void Init()
        {
            code = "ES";
        }

        [Test]
        public void ItShouldCreateNewCountryCode()
        {
            CountryCode countryCode = new CountryCode(this.code);

            Assert.IsNotNull(countryCode);
            Assert.AreEqual(countryCode.GetValue(), this.code);
        }

        [Test]
        public void ItShouldReturnTrueWhenTwoCountryCodeAreEqual()
        {
            CountryCode countryCode1 = new CountryCode(this.code);
            CountryCode countryCode2 = new CountryCode(this.code);

            Assert.IsTrue(countryCode1.Equals(countryCode2));
        }
    }
}
