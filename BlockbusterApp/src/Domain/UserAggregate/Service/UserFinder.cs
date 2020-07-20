using BlockbusterApp.src.Domain.UserAggregate.Service.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Domain.UserAggregate.Service
{
    public class UserFinder
    {

        private IUserRepository userRepository;

        public UserFinder(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public User ById(UserId id)
        {
            var user = this.userRepository.FindUserById(id);

            if (user is null)
            {
                throw UserNotFoundException.FromId(id);
            }
            
            return user;
        }

    }
}
