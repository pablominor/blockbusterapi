using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using System.Collections.Generic;

namespace BlockbusterApp.src.Application.UseCase.User.GetAll
{
    public class GetUsersResponse : IResponse
    {
        public List<UserDTO> AllUsers;
    }
}
