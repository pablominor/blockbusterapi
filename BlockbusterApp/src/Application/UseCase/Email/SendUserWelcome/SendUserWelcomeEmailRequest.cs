using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Application.UseCase.Email.SendUserWelcome
{
    public class SendUserWelcomeEmailRequest : IRequest
    {
        public SendUserWelcomeEmailRequest(string Email, string FirstName, string LastName)
        {
            this.Email = Email;
            this.FirstName = FirstName;
            this.LastName = LastName;
        }

        public string Email { get; }
        public string FirstName { get; }
        public string LastName { get; }

    }
}
