using BlockbusterApp.src.Shared.Domain;
using Microsoft.Extensions.Configuration;
using System;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace BlockbusterApp.src.Infraestructure.Service.Mailer
{
    public class SMTPMailer : IMailer
    {
        private string host;
        private string from;
        private string password;
        private string alias;
        private string port;

        public SMTPMailer(IConfiguration iConfiguration)
        {
            var smtpSection = iConfiguration.GetSection("SMTP");
            if (smtpSection != null)
            {
                this.host = smtpSection.GetSection("Host").Value;
                this.from = smtpSection.GetSection("From").Value;
                this.password = smtpSection.GetSection("Password").Value;
                this.alias = smtpSection.GetSection("Alias").Value;
                this.port = smtpSection.GetSection("Port").Value;
            }
        }

        public void Send(EmailModel emailModel)
        {
            SmtpClient smtpClient = ConfigSmtpClient();
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(this.from, this.alias);
            mailMessage.BodyEncoding = Encoding.UTF8;
            mailMessage.To.Add(emailModel.GetTo());            
            mailMessage.Body = emailModel.GetBody();
            mailMessage.Subject = emailModel.GetSubject();
            smtpClient.Send(mailMessage);            
        }


        private SmtpClient ConfigSmtpClient()
        {
            SmtpClient smtpClient = new SmtpClient(this.host);
            smtpClient.Credentials = new NetworkCredential(this.from, this.password);
            smtpClient.Port = Int32.Parse(this.port);            
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;            
            smtpClient.EnableSsl = true;
            return smtpClient;
        }
    }
}
