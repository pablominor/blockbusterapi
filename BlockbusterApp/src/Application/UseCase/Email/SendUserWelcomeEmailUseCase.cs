using BlockbusterApp.src.Infraestructure.Service.Mailer;
using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Application.UseCase.Email
{
    public class SendUserWelcomeEmailUseCase : IUseCase
    {

        private IMailer _mailer;
        private WelcomeEmailConverter _welcomeEmailConverter;

        public SendUserWelcomeEmailUseCase(IMailer mailer, WelcomeEmailConverter welcomeEmailConverter) 
        {
            _mailer = mailer;
            _welcomeEmailConverter = welcomeEmailConverter;
        }

        public IResponse Execute(IRequest req)
        {
            SendUserWelcomeEmailRequest request = req as SendUserWelcomeEmailRequest;

            string email = request.Email;
            string firstName = request.FirstName;
            string lastName = request.LastName;
            string fullName = firstName + " " + lastName;

            _mailer.Send("pablo3vias@gmail.com",email,"Welcome Email",String.Format("Gracias por registrarte {0}. Recuerda que para iniciar sesión en nuestra aplicación debe usar su email.",fullName));

            return _welcomeEmailConverter.Convert();
        }
    }
}
