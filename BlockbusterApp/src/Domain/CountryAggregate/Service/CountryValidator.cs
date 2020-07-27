using BlockbusterApp.src.Domain.CountryAggregate.Service.Exception;

namespace BlockbusterApp.src.Domain.CountryAggregate.Service
{
    public class CountryValidator
    {
        private ICountryRepository countryRepository;

        public CountryValidator(ICountryRepository countryRepository)
        {
            this.countryRepository = countryRepository;
        }

        public virtual void Validate(CountryCode countryCode)
        {
            var country = this.countryRepository.FindCountryByCode(countryCode);
            if (country == null)
            {
                throw CountryNotFoundException.Fromcode(countryCode);
            }
        }
    }
}
