using BlockbusterApp.src.Application.UseCase.User.GetAll;
using BlockbusterApp.src.Shared.Application.Bus.UseCase;

namespace BlockbusterApp.src.Application.UseCase.User.GetUserPersonalData
{
    public class GetUserPersonalDataConverter
    {
        public GetUserPersonalDataConverter() { }

        public IResponse Convert(Domain.UserAggregate.User user)
        {                        
            string id = user.userId.GetValue();
            string email = user.userEmail.GetValue();
            string firstName = user.userFirstName.GetValue();
            string lastName = user.userLastName.GetValue();
            string role = user.userRole.GetValue();
            UserDTO userDTO = new UserDTO(id, email, firstName, lastName, role);

            GetUserPersonalDataResponse response = new GetUserPersonalDataResponse
            {
                User = userDTO
            };

            return response;
        }
    }
}
