using BlockbusterApp.src.Infraestructure.Service.Mailer;
using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using BlockbusterApp.src.Shared.Domain;

namespace BlockbusterApp.src.Application.UseCase.Email.SendUserWelcome
{
    public class SendUserWelcomeEmailUseCase : IUseCase
    {
        private WelcomeEmailModelFactory welcomeEmailModelFactory;
        private IMailer mailer;
        private WelcomeEmailConverter welcomeEmailConverter;

        public SendUserWelcomeEmailUseCase(WelcomeEmailModelFactory welcomeEmailModelFactory, IMailer mailer, WelcomeEmailConverter welcomeEmailConverter) 
        {
            this.welcomeEmailModelFactory = welcomeEmailModelFactory;
            this.mailer = mailer;
            this.welcomeEmailConverter = welcomeEmailConverter;
        }

        public IResponse Execute(IRequest req)
        {
            SendUserWelcomeEmailRequest request = req as SendUserWelcomeEmailRequest;
            EmailModel emailModel = this.welcomeEmailModelFactory.Create(request);

            this.mailer.Send(emailModel);

            return this.welcomeEmailConverter.Convert();

        }
    }
}
