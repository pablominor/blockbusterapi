using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using BlockbusterApp.src.Shared.Application.Bus.UseCase.Response;

namespace BlockbusterApp.src.Application.UseCase.User.Response
{
    public class FindUserResponseConverter : ResponseConverter
    {
        public FindUserResponseConverter() { }

        public virtual IResponse Convert(dynamic item)
        {
            Domain.UserAggregate.User user = item as Domain.UserAggregate.User;

            string id = user.userId.GetValue();
            string email = user.userEmail.GetValue();
            string firstName = user.userFirstName.GetValue();
            string lastName = user.userLastName.GetValue();
            string role = user.userRole.GetValue();
            string countryCode = user.userCountryCode.GetValue();
            FindUserResponse response = new FindUserResponse
            {
                Id = id,
                Email = email,
                FirstName = firstName,
                LastName = lastName,
                Role = role,
                CountryCode = countryCode
            };

            return response;
        }
    }
}
