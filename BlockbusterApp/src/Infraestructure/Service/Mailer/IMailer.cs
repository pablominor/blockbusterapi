using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Infraestructure.Service.Mailer
{
    public interface IMailer
    {
        void Send(string from, string to, string subject, string body);
    }
}
