using BlockbusterApp.src.Shared.Domain;
using System.ComponentModel.DataAnnotations;

namespace BlockbusterApp.src.Domain.CountryAggregate
{
    public class Country : AggregateRoot
    {
        [Key]
        public CountryCode code { get; }
        public CountryTax tax { get; }

        private Country (CountryCode code, CountryTax tax)
        {
            this.code = code;
            this.tax = tax;
        }

        public static Country Create(CountryCode code, CountryTax tax)
        {
            Country country = new Country(code, tax);
            return country;
        }
    }
}
