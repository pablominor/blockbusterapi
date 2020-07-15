using BlockbusterApp.src.Application.UseCase.User.GetAll;
using BlockbusterApp.src.Shared.Application.Bus.UseCase;

namespace BlockbusterApp.src.Application.UseCase.User.GetUserPersonalData
{
    public class GetUserPersonalDataResponse : IResponse
    {
        public UserDTO User;
    }
}
