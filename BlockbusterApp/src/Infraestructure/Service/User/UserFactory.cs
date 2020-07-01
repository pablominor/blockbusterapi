using BlockbusterApp.src.Domain.UserAggregate;
using BlockbusterApp.src.Infraestructure.Service.Hashing;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Infraestructure.Service.User
{
    public class UserFactory : IUserFactory
    {
        private IHashing _hashing;

        public UserFactory(IHashing hashing)
        {
            _hashing = hashing;
        }

        public Domain.UserAggregate.User Create(
            string id, 
            string email, 
            string password, 
            string repeatPassword, 
            string firstName, 
            string lastName, 
            string role)
        {
            UserId userId = new UserId(id);
            UserEmail userEmail = new UserEmail(email);
            UserPassword userPassword = new UserPassword(password);

            UserPassword.Validate(password, repeatPassword);

            UserFirstName userFirstName = new UserFirstName(firstName);
            UserLastName userLastName = new UserLastName(lastName);
            UserRole userRole = new UserRole(role);

            UserHashedPassword userHashedPassword = _hashing.Hash(password);

            return Domain.UserAggregate.User.SignUp(
                userId,
                userEmail,
                userHashedPassword,
                userFirstName,
                userLastName,
                userRole);
        }
    }
}
