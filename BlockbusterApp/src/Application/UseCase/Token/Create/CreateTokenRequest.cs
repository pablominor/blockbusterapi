using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Application.UseCase.Token.Create
{
    public class CreateTokenRequest : IRequest
    {
        public CreateTokenRequest(string Email, string Password)
        {
            this.Email = Email;
            this.Password = Password;
        }

        public string Email { get; }
        public string Password { get; }
    }
}
