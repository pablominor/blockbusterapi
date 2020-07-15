using BlockbusterApp.src.Shared.Application.Bus.UseCase;

namespace BlockbusterApp.src.Application.UseCase.User.GetUserPersonalData
{
    public class GetUserPersonalDataRequest : IRequest
    {

        public GetUserPersonalDataRequest(string Id)
        {
            this.Id = Id;            
        }

        public string Id { get; }
    }
}
