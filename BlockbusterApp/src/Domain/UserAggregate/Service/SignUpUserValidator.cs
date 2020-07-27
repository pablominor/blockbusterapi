using BlockbusterApp.src.Domain.UserAggregate.Service.Exception;

namespace BlockbusterApp.src.Domain.UserAggregate.Service
{
    public class SignUpUserValidator
    {
        private IUserRepository userRepository;

        public SignUpUserValidator(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public virtual void Validate(UserEmail userEmail)
        {
            var user = this.userRepository.FindUserByEmail(userEmail);
            if (user != null)
            {
                throw UserFoundException.FromEmail(userEmail);
            }
        }

    }
}
