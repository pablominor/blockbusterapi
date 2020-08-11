using BlockbusterApp.src.Application.UseCase.Country.FindByCode;
using NUnit.Framework;
using UnitTest.Domain.CountryAggregate.Stub;

namespace UnitTest.Application.UseCase.Country.FindByCode
{
    [TestFixture]
    public class CountryResponseConverterTest
    {

        [Test]
        public void ItShouldReturnCorrectResponse()
        {
            BlockbusterApp.src.Domain.CountryAggregate.Country country = CountryStub.ByDefault();
            CountryResponseConverter converter = new CountryResponseConverter();

            var res = converter.Convert(country);

            Assert.IsInstanceOf<CountryResponse>(res);
            CountryResponse response = res as CountryResponse;
            Assert.AreEqual(response.Country.code.GetValue(), country.code.GetValue());
            Assert.AreEqual(response.Country.tax.GetValue(), country.tax.GetValue());
        }

    }
}
