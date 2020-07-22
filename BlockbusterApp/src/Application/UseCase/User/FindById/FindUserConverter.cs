using BlockbusterApp.src.Application.UseCase.User.FindByFilter;
using BlockbusterApp.src.Shared.Application.Bus.UseCase;

namespace BlockbusterApp.src.Application.UseCase.User.FindById
{
    public class FindUserConverter
    {
        public FindUserConverter() { }

        public IResponse Convert(Domain.UserAggregate.User user)
        {                        
            string id = user.userId.GetValue();
            string email = user.userEmail.GetValue();
            string firstName = user.userFirstName.GetValue();
            string lastName = user.userLastName.GetValue();
            string role = user.userRole.GetValue();
            string countryCode = user.userCountryCode.GetValue();
            UserDTO userDTO = new UserDTO(id, email, firstName, lastName, role, countryCode);

            FindUserResponse response = new FindUserResponse
            {
                User = userDTO
            };

            return response;
        }
    }
}
