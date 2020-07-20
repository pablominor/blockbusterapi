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
        private string _host;
        private string _from;
        private string _password;
        private string _alias;
        private string _port;

        public SMTPMailer(IConfiguration iConfiguration)
        {
            var smtpSection = iConfiguration.GetSection("SMTP");
            if (smtpSection != null)
            {
                _host = smtpSection.GetSection("Host").Value;
                _from = smtpSection.GetSection("From").Value;
                _password = smtpSection.GetSection("Password").Value;
                _alias = smtpSection.GetSection("Alias").Value;
                _port = smtpSection.GetSection("Port").Value;
            }
        }

        public void Send(EmailModel emailModel)
        {
            SmtpClient smtpClient = ConfigSmtpClient();
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(_from, _alias);
            mailMessage.BodyEncoding = Encoding.UTF8;
            mailMessage.To.Add(emailModel.GetTo());            
            mailMessage.Body = emailModel.GetBody();
            mailMessage.Subject = emailModel.GetSubject();
            smtpClient.Send(mailMessage);            
        }


        private SmtpClient ConfigSmtpClient()
        {
            SmtpClient smtpClient = new SmtpClient(_host);
            smtpClient.Credentials = new NetworkCredential(_from, _password);
            smtpClient.Port = Int32.Parse(_port);            
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;            
            smtpClient.EnableSsl = true;
            return smtpClient;
        }
    }
}
