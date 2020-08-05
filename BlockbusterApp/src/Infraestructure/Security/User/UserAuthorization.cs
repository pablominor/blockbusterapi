using BlockbusterApp.src.Domain.UserAggregate;
using BlockbusterApp.src.Infraestructure.Security.User.Exception;
using BlockbusterApp.src.Shared.Infraestructure.Security.Authentication.JWT;

namespace BlockbusterApp.src.Infraestructure.Security.User
{
    public class UserAuthorization : IUserAuthorization
    {

        private IUserProvider userProvider;

        public UserAuthorization(IUserProvider userProvider)
        {
            this.userProvider = userProvider;
        }

        public void AuthorizeAsOwner(UserId id)
        {
            if(id.GetValue() != this.userProvider.GetUserId())
            {
                throw new UserAuthorizationException("the user is not the owner of the data");
            }            
        }
    }
}
