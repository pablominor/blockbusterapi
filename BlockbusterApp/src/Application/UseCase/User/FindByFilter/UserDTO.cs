

namespace BlockbusterApp.src.Application.UseCase.User.FindByFilter
{
    public class UserDTO
    {
        public string id ;
        public string email ;
        public string firstName ;
        public string lastName ;
        public string role ;
        public string countryCode;

        public UserDTO(
            string id, 
            string email, 
            string firstName, 
            string lastName, 
            string role,
            string countryCode) 
        {
            this.id = id;
            this.email = email;
            this.firstName = firstName;
            this.lastName = lastName;
            this.role = role;
            this.countryCode = countryCode;
        }        
    }
}
