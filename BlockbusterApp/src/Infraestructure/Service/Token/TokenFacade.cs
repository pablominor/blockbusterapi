using BlockbusterApp.src.Domain.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Infraestructure.Service.Token
{
    public class TokenFacade
    {

        private IUserRepository userRepository;

        public TokenFacade(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public Domain.UserAggregate.User FindUserFromEmailAndPassword(string email,string password)
        {
            Domain.UserAggregate.User user = this.userRepository.FindUserByEmail(new UserEmail(email));
            //todo usecasebus
            //todo check with password
            return user;
        }       
    }
}
