using BlockbusterApp.src.Infraestructure.Service.Mailer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Application.UseCase.Email
{
    public class WelcomeEmailModelFactory
    {
        public const string WELCOME_SUBJECT = "Welcome email";

        public virtual EmailModel Create(SendUserWelcomeEmailRequest request)
        {            
            string to = request.Email;
            string fullName = request.FirstName + " " + request.LastName;
            string body = String.Format("Gracias por registrarte {0}. Recuerda que para iniciar sesión en nuestra aplicación debe usar su email.", fullName);
            return new EmailModel(to, WELCOME_SUBJECT, body);
        }
    }
}
