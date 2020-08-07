using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using BlockbusterApp.src.Shared.Application.Bus.UseCase.Response;

namespace BlockbusterApp.src.Application.UseCase.User.FindById
{
    public class FindUserResponseConverter : ResponseConverter
    {
        public FindUserResponseConverter() { }

        public IResponse Convert(dynamic item)
        {
            Domain.UserAggregate.User user = item as Domain.UserAggregate.User;

            string id = user.userId.GetValue();
            string email = user.userEmail.GetValue();
            string firstName = user.userFirstName.GetValue();
            string lastName = user.userLastName.GetValue();
            string role = user.userRole.GetValue();
            string countryCode = user.userCountryCode.GetValue();
            FindUserResponse response = new FindUserResponse(
                    id, 
                    email, 
                    firstName, 
                    lastName, 
                    role, 
                    countryCode);

            return response;
        }
    }
}
