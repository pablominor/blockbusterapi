using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using BlockbusterApp.src.Shared.Application.Bus.UseCase.Response;

namespace BlockbusterApp.src.Application.UseCase.User.FindByEmalAndPassword
{
    public class UserResponseConverter : ResponseConverter
    {

        public UserResponseConverter() { }

        public virtual IResponse Convert(dynamic item)
        {
            Domain.UserAggregate.User user = item as Domain.UserAggregate.User;
            return new UserResponse(user);
        }
    }
}
