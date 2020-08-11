using BlockbusterApp.src.Application.UseCase.Country.FindByCode;
using NUnit.Framework;
using System;
using UnitTest.Domain.CountryAggregate.Stub;

namespace UnitTest.Application.UseCase.Country.FindByCode
{
    [TestFixture]
    public class CountryResponseTest
    {

        [Test]
        public void ItShouldReturnCorrectResponse()
        {
            BlockbusterApp.src.Domain.CountryAggregate.Country country = CountryStub.ByDefault();

            CountryResponse request = new CountryResponse(country);

            Assert.AreEqual(request.Country.code.GetValue(), country.code.GetValue());
            Assert.AreEqual(request.Country.tax.GetValue(), country.tax.GetValue());
        }
    }
}
