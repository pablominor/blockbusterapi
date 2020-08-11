using BlockbusterApp.src.Domain.CountryAggregate;

namespace UnitTest.Domain.CountryAggregate.Stub
{
    public class CountryCodeStub
    {

        public static CountryCode Create(string code)
        {
            return new CountryCode(code);
        }

        public static CountryCode ByDefault()
        {
            return new CountryCode("ES");
        }
    }
}
