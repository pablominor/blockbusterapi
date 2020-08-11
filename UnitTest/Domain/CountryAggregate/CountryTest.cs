using BlockbusterApp.src.Domain.CountryAggregate;
using NUnit.Framework;
using UnitTest.Domain.CountryAggregate.Stub;

namespace UnitTest.Domain.CountryAggregate
{
    [TestFixture]
    public class CountryTest
    {

        [Test]
        public void ItShouldCreateNewCountry()
        {
            CountryCode code = CountryCodeStub.ByDefault();
            CountryTax tax = CountryTaxStub.ByDefault();

            Country country = Country.Create(code,tax);

            Assert.IsNotNull(country);
            Assert.IsTrue(country.code.Equals(code));
            Assert.IsTrue(country.tax.Equals(tax));
        }

    }
}
