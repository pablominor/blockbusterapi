using BlockbusterApp.src.Domain.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Shared.Infraestructure.Security.Authentication.JWT.Entity
{
    public class AuthUser
    {

        public string userId { get; }
        public string email { get; }
        public string firstName { get; }
        public string lastName { get; }
        public string role { get;}


        private AuthUser(
            string userId,
            string email,
            string firstName,
            string lastName,
            string role)
        {
            this.userId = userId;
            this.email = email;
            this.firstName = firstName;
            this.lastName = lastName;
            this.role = role;
        }


        public static AuthUser Create(
            string userId,
            string email,
            string firstName,
            string lastName,
            string role)
        {
            return new AuthUser(userId, email, firstName, lastName, role);
        }

    }   
}
