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
        private IHashing hashing;

        public UserFactory(IHashing hashing)
        {
            this.hashing = hashing;
        }

        public Domain.UserAggregate.User Create(
            string id, 
            string email, 
            string password, 
            string repeatPassword, 
            string firstName, 
            string lastName, 
            string role,
            string countryCode)
        {
            UserId userId = new UserId(id);
            UserEmail userEmail = new UserEmail(email);
            UserPassword userPassword = new UserPassword(password);

            UserPassword.Validate(password, repeatPassword);

            UserFirstName userFirstName = new UserFirstName(firstName);
            UserLastName userLastName = new UserLastName(lastName);
            UserRole userRole = new UserRole(role);
            UserCountryCode userCountryCode = new UserCountryCode(countryCode);

            UserHashedPassword userHashedPassword = this.hashing.Hash(password);

            return Domain.UserAggregate.User.SignUp(
                userId,
                userEmail,
                userHashedPassword,
                userFirstName,
                userLastName,
                userRole,
                userCountryCode);
        }
    }
}
