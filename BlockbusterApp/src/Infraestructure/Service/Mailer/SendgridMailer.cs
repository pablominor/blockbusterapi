using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Infraestructure.Service.Mailer
{
    public class SendgridMailer : IMailer
    {
        public SendgridMailer()
        {

        }

        public void Send(string from, string to, string subject, string body)
        {
            throw new NotImplementedException();
        }
    }
}
