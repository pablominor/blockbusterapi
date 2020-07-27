using BlockbusterApp.src.Shared.Domain;

namespace BlockbusterApp.src.Domain.CountryAggregate
{
    public class CountryTax : DecimalValueObject
    {
        public CountryTax(decimal value) : base(value)
        {

        }
    }
}
