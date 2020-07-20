using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using System.Collections.Generic;

namespace BlockbusterApp.src.Application.UseCase.User.FindByFilter
{
    public class GetUsersConverter
    {

        public GetUsersConverter() { }

        public IResponse Convert(IEnumerable<Domain.UserAggregate.User> users) 
        {
            List<UserDTO> usersConverted = new List<UserDTO>();

            foreach(var user in users)
            {
                string id = user.userId.GetValue();
                string email = user.userEmail.GetValue();
                string firstName = user.userFirstName.GetValue();
                string lastName = user.userLastName.GetValue();
                string role = user.userRole.GetValue();
                UserDTO userDTO = new UserDTO(id, email, firstName, lastName, role);
                usersConverted.Add(userDTO);
            }

            GetUsersResponse response = new GetUsersResponse
            {
                AllUsers = usersConverted
            };

            return response;
        }

    }
}
