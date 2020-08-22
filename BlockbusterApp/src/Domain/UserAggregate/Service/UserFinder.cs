using BlockbusterApp.src.Domain.UserAggregate.Service.Exception;

namespace BlockbusterApp.src.Domain.UserAggregate.Service
{
    public class UserFinder
    {

        private IUserRepository userRepository;

        public UserFinder(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public virtual User FindOneById(UserId id)
        {
            var user = this.userRepository.FindUserById(id);

            if (user is null)
            {
                throw UserNotFoundException.FromId(id);
            }
            
            return user;
        }

        public virtual User ByEmailAndPassword(UserEmail email,UserHashedPassword hashedPassword)
        {
            var user = this.userRepository.FindUserByEmailAndPassword(email,hashedPassword);

            if (user is null)
            {
                throw UserNotFoundException.FromEmailAndPassword();
            }

            return user;
        }

    }
}
