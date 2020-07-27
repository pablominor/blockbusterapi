

namespace BlockbusterApp.src.Domain.CountryAggregate
{
    public interface ICountryRepository
    {
        Country FindCountryByCode(CountryCode code);
    }
}
