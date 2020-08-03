using BlockbusterApp.src.Application.UseCase.User.FindByFilter;
using BlockbusterApp.src.Shared.Application.Bus.UseCase;

namespace BlockbusterApp.src.Application.UseCase.User.FindById
{
    public class FindUserResponse : UserDTO,IResponse
    {
        public FindUserResponse(
            string id,
            string email,
            string firstName,
            string lastName,
            string role,
            string countryCode) 
            : base(
                id,
                email,
                firstName,
                lastName,
                role,
                countryCode){ }
    }
}
