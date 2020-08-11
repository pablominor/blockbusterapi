using BlockbusterApp.src.Shared.Application.Bus.UseCase;

namespace BlockbusterApp.src.Application.UseCase.Country.FindByCode
{
    public class FindCountryByCodeRequest : IRequest
    {

        public FindCountryByCodeRequest(string Code)
        {
            this.Code = Code;
        }

        public string Code { get; }        
    }
}
