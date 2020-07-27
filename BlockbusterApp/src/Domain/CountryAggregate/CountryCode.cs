using BlockbusterApp.src.Shared.Domain;

namespace BlockbusterApp.src.Domain.CountryAggregate
{
    public class CountryCode : StringValueObject
    {
        public CountryCode(string value) : base(value)
        {
        }
    }
}
