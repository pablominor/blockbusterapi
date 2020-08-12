using BlockbusterApp.src.Shared.Infraestructure.Security.Authentication.JWT.Entity;

namespace BlockbusterApp.src.Shared.Infraestructure.Security.Authentication.JWT
{
    public interface IUserProvider
    {
        AuthUser GetUser();
    }
}
