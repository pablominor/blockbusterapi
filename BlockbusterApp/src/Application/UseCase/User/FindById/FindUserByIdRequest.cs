using BlockbusterApp.src.Shared.Application.Bus.UseCase;

namespace BlockbusterApp.src.Application.UseCase.User.FindById
{
    public class FindUserByIdRequest : IRequest
    {

        public FindUserByIdRequest(string Id)
        {
            this.Id = Id;            
        }

        public string Id { get; }
    }
}
