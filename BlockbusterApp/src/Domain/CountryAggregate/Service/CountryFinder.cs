using BlockbusterApp.src.Domain.CountryAggregate.Service.Exception;

namespace BlockbusterApp.src.Domain.CountryAggregate.Service
{
    public class CountryFinder
    {
        private ICountryRepository countryRepository;

        public CountryFinder(ICountryRepository countryRepository)
        {
            this.countryRepository = countryRepository;
        }

        public virtual Country ByCode(CountryCode countryCode)
        {
            var country = this.countryRepository.FindCountryByCode(countryCode);
            if (country == null)
            {
                throw CountryNotFoundException.Fromcode(countryCode);
            }
            return country;
        }

    }
}
