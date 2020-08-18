using BlockbusterApp.src.Application.UseCase.Country.Response;
using BlockbusterApp.src.Domain.CountryAggregate;
using BlockbusterApp.src.Domain.CountryAggregate.Service;
using BlockbusterApp.src.Shared.Application.Bus.UseCase;

namespace BlockbusterApp.src.Application.UseCase.Country.FindByCode
{
    public class FindCountryByCodeUseCase : IUseCase
    {
        private CountryFinder countryFinder;
        private CountryResponseConverter converter;

        public FindCountryByCodeUseCase(CountryFinder countryFinder, CountryResponseConverter converter)
        {
            this.countryFinder = countryFinder;
            this.converter = converter;
        }

        public IResponse Execute(IRequest req)
        {
            FindCountryByCodeRequest request = req as FindCountryByCodeRequest;

            CountryCode countryCode = new CountryCode(request.Code);            

            var country = countryFinder.ByCode(countryCode);

            return this.converter.Convert(country);       
        }
    }
}
