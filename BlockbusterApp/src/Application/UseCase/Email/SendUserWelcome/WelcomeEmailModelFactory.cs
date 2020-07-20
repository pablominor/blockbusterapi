using BlockbusterApp.src.Shared.Domain;
using Microsoft.Extensions.Configuration;
using System;

namespace BlockbusterApp.src.Application.UseCase.Email.SendUserWelcome
{
    public class WelcomeEmailModelFactory
    {       
        private IConfiguration configuration;

        public WelcomeEmailModelFactory(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public virtual EmailModel Create(SendUserWelcomeEmailRequest request)
        {
            var welcomeEmailSection = this.configuration.GetSection("WelcomeEmail");
            string from = "";
            string subject = "";
            if (welcomeEmailSection != null)
            {
                from = welcomeEmailSection.GetSection("From").Value;
                subject = welcomeEmailSection.GetSection("Subject").Value;
            }

            string to = request.Email;
            string fullName = request.FirstName + " " + request.LastName;
            string body = String.Format("Gracias por registrarte {0}. Recuerda que para iniciar sesión en nuestra aplicación debe usar su email.", fullName);          
            return new EmailModel(from,to, subject, body);
        }
    }
}
