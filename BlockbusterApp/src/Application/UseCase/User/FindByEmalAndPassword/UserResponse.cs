using BlockbusterApp.src.Shared.Application.Bus.UseCase;

namespace BlockbusterApp.src.Application.UseCase.User.FindByEmalAndPassword
{
    public class UserResponse : IResponse
    {

        public UserResponse(Domain.UserAggregate.User User)
        {
            this.User = User;
        }

        public Domain.UserAggregate.User User;
    }
}
