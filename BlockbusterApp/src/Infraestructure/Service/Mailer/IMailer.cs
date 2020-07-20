using BlockbusterApp.src.Shared.Domain;

namespace BlockbusterApp.src.Infraestructure.Service.Mailer
{
    public interface IMailer
    {        
        void Send(EmailModel emailModel);
    }
}
