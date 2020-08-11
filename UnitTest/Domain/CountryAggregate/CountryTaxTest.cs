using BlockbusterApp.src.Domain.CountryAggregate;
using NUnit.Framework;

namespace UnitTest.Domain.CountryAggregate
{
    [TestFixture]
    public class CountryTaxTest
    {

        private decimal tax;

        [SetUp]
        public void Init()
        {
            tax = 21;
        }


        [Test]
        public void ItShouldCreateNewCountryCode()
        {
            CountryTax countryTax = new CountryTax(this.tax);

            Assert.IsNotNull(countryTax);
            Assert.AreEqual(countryTax.GetValue(), this.tax);
        }

        [Test]
        public void ItShouldReturnTrueWhenTwoCountryCodeAreEqual()
        {
            CountryTax countryTax1 = new CountryTax(this.tax);
            CountryTax countryTax2 = new CountryTax(this.tax);

            Assert.IsTrue(countryTax1.Equals(countryTax2));
        }
    }
}
