using BlockbusterApp.src.Infraestructure.Service.Mailer;
using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using BlockbusterApp.src.Shared.Domain;

namespace BlockbusterApp.src.Application.UseCase.Email.SendUserWelcome
{
    public class SendUserWelcomeEmailUseCase : IUseCase
    {
        private WelcomeEmailModelFactory welcomeEmailModelFactory;
        private IMailer mailer;
        private EmptyResponseConverter emptyResponseConverter;

        public SendUserWelcomeEmailUseCase(WelcomeEmailModelFactory welcomeEmailModelFactory, IMailer mailer, EmptyResponseConverter emptyResponseConverter) 
        {
            this.welcomeEmailModelFactory = welcomeEmailModelFactory;
            this.mailer = mailer;
            this.emptyResponseConverter = emptyResponseConverter;
        }

        public IResponse Execute(IRequest req)
        {
            SendUserWelcomeEmailRequest request = req as SendUserWelcomeEmailRequest;
            EmailModel emailModel = this.welcomeEmailModelFactory.Create(request);

            this.mailer.Send(emailModel);

            return this.emptyResponseConverter.Convert();

        }
    }
}
