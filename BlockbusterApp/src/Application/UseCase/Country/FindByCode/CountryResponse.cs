using BlockbusterApp.src.Shared.Application.Bus.UseCase;

namespace BlockbusterApp.src.Application.UseCase.Country.FindByCode
{
    public class CountryResponse : IResponse
    {
        public CountryResponse(Domain.CountryAggregate.Country Country)
        {
            this.Country = Country;
        }

        public Domain.CountryAggregate.Country Country;
    }
}
