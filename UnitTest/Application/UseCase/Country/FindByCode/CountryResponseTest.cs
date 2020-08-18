using BlockbusterApp.src.Application.UseCase.Country.FindByCode;
using BlockbusterApp.src.Application.UseCase.Country.Response;
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

            CountryResponse request = new CountryResponse { 
                Code = country.code.GetValue(),
                Tax = country.tax.GetValue()
            };

            Assert.AreEqual(request.Code, country.code.GetValue());
            Assert.AreEqual(request.Tax, country.tax.GetValue());
        }
    }
}
