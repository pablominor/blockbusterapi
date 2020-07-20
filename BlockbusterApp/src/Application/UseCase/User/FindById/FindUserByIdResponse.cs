using BlockbusterApp.src.Application.UseCase.User.FindByFilter;
using BlockbusterApp.src.Shared.Application.Bus.UseCase;

namespace BlockbusterApp.src.Application.UseCase.User.FindById
{
    public class FindUserByIdResponse : IResponse
    {
        public UserDTO User;
    }
}
