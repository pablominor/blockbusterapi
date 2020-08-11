using BlockbusterApp.src.Domain.CountryAggregate;

namespace UnitTest.Domain.CountryAggregate.Stub
{
    public class CountryStub
    {

        public static Country ByDefault()
        {
            return Create(
                CountryCodeStub.ByDefault(),
                CountryTaxStub.ByDefault()
            );
        }


        private static Country Create(
            CountryCode Code,
            CountryTax Tax)
        {
            return Country.Create(Code,Tax);
        }
    }
}
