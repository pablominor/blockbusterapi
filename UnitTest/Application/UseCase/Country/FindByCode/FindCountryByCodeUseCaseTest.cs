using BlockbusterApp.src.Application.UseCase.Country.FindByCode;
using BlockbusterApp.src.Domain.CountryAggregate;
using BlockbusterApp.src.Domain.CountryAggregate.Service;
using Moq;
using NUnit.Framework;
using UnitTest.Domain.CountryAggregate.Stub;
using UnitTest.Domain.Repository;

namespace UnitTest.Application.UseCase.Country.FindByCode
{
    [TestFixture]
    public class FindCountryByCodeUseCaseTest
    {

        [Test]
        public void ItShouldCallCollaborators()
        {
            FindCountryByCodeRequest request = FindCountryByCodeRequestStub.ByDefault();
            BlockbusterApp.src.Domain.CountryAggregate.Country country = CountryStub.ByDefault();
            Mock<ICountryRepository> countryRepository = RepositoryMockGenerator.CreateCountryRepository();
            Mock<CountryFinder> countryFinder = new Mock<CountryFinder>(countryRepository.Object);
            countryFinder.Setup(o => o.ByCode(It.IsAny<CountryCode>())).Returns(country);
            Mock<CountryResponseConverter> converter = new Mock<CountryResponseConverter>();
            converter.Setup(o => o.Convert(country));
            FindCountryByCodeUseCase useCase = new FindCountryByCodeUseCase(countryFinder.Object,converter.Object);

            useCase.Execute(request);

            countryFinder.VerifyAll();
            converter.VerifyAll();
        }

    }
}
