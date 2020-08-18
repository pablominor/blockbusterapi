using BlockbusterApp.src.Application.UseCase.Country.Response;
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
            Assert.AreEqual(response.Code, country.code.GetValue());
            Assert.AreEqual(response.Tax, country.tax.GetValue());
        }

    }
}
