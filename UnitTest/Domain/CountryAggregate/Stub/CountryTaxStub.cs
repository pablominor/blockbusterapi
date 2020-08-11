using BlockbusterApp.src.Domain.CountryAggregate;

namespace UnitTest.Domain.CountryAggregate.Stub
{
    public class CountryTaxStub
    {

        public static CountryTax Create(decimal tax)
        {
            return new CountryTax(tax);
        }

        public static CountryTax ByDefault()
        {
            return new CountryTax(21);
        }
    }
}
