using BlockbusterApp.src.Shared.Application.Bus.UseCase;

namespace BlockbusterApp.src.Application.UseCase.User.FindByEmalAndPassword
{
    public class FindUserByEmailAndPasswordRequest : IRequest
    {

        public FindUserByEmailAndPasswordRequest(string Email,string Password)
        {
            this.Email = Email;
            this.Password = Password;
        }

        public string Email { get; }
        public string Password { get; }
    }
}
