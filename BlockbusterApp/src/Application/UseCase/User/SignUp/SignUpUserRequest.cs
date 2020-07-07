using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Application.UseCase.User.SignUP
{
    public class SignUpUserRequest : IRequest
    {

        public SignUpUserRequest(
            string Id,
            string Email,
            string Password,
            string RepeatPassword,
            string FirstName,
            string LastName,
            string Role
            )
        {
            this.Id = Id;
            this.Email = Email;
            this.Password = Password;
            this.RepeatPassword = RepeatPassword;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Role = Role;
        }

        public string Id { get; }
        public string Email { get; }
        public string Password { get; }
        public string RepeatPassword { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Role { get; }

    }
}
