using BlockbusterApp.src.Domain.CountryAggregate;
using BlockbusterApp.src.Domain.CountryAggregate.Service;
using BlockbusterApp.src.Domain.CountryAggregate.Service.Exception;
using BlockbusterApp.src.Domain.UserAggregate;
using BlockbusterApp.src.Shared.Domain.Exception;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using UnitTest.Domain.CountryAggregate.Stub;
using UnitTest.Domain.Repository;

namespace UnitTest.Domain.CountryAggregate.Service
{
    [TestFixture]
    public class CountryFinderTest
    {

        [Test]
        public void ItShouldThrowExceptionFromCountryNotFoundByCode()
        {
            Country country = null;
            Mock<ICountryRepository> countryRepository = RepositoryStub.CreateCountryRepository();
            countryRepository.Setup(o => o.FindCountryByCode(It.IsAny<CountryCode>())).Returns(country);
            CountryFinder countryFinder = new CountryFinder(countryRepository.Object);

            var Exception = Assert.Throws<CountryNotFoundException>(() => countryFinder.ByCode(CountryCodeStub.ByDefault()));

            Assert.Pass(Exception.Message, CountryNotFoundException.Fromcode(CountryCodeStub.ByDefault()));
            Assert.IsInstanceOf<ValidationException>(Exception);
        }

        [Test]
        public void ItShouldFindCountryByCode()
        {
            Country country = CountryStub.ByDefault();
            Mock<ICountryRepository> countryRepository = RepositoryStub.CreateCountryRepository();
            countryRepository.Setup(o => o.FindCountryByCode(It.IsAny<CountryCode>())).Returns(country);
            CountryFinder countryFinder = new CountryFinder(countryRepository.Object);

            var countryfound = countryFinder.ByCode(CountryCodeStub.ByDefault());

            Assert.IsNotNull(countryfound);
            Assert.IsInstanceOf<Country>(countryfound);
        }
    }
}
