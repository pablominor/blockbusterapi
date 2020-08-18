using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using BlockbusterApp.src.Shared.Application.Bus.UseCase.Response;

namespace BlockbusterApp.src.Application.UseCase.Country.Response
{
    public class CountryResponseConverter : ResponseConverter
    {
        public CountryResponseConverter() { }

        public virtual IResponse Convert(dynamic item)
        {
            Domain.CountryAggregate.Country country = item as Domain.CountryAggregate.Country;

            return new CountryResponse()
            {
                Code = country.code.GetValue(),
                Tax = country.tax.GetValue()
            };

        }
    }
}
