using BlockbusterApp.src.Application.UseCase.Country.FindByCode;
using UnitTest.Domain.CountryAggregate.Stub;

namespace UnitTest.Application.UseCase.Country.FindByCode
{
    public class FindCountryByCodeRequestStub
    {
        public static FindCountryByCodeRequest Create(string code)
        {
            return new FindCountryByCodeRequest(code);
        }

        public static FindCountryByCodeRequest ByDefault()
        {
            return new FindCountryByCodeRequest(
                CountryCodeStub.ByDefault().GetValue()                
            );
        }
    }
}
