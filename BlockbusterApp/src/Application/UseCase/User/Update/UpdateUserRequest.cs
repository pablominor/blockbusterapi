using BlockbusterApp.src.Shared.Application.Bus.UseCase;

namespace BlockbusterApp.src.Application.UseCase.User.Update
{
    public class UpdateUserRequest : IRequest
    {
        public UpdateUserRequest(
            string FirstName,
            string LastName,
            string Password)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Password = Password;            
        }

        public string Id { get; set; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Password { get; }

    }
}
