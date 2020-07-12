using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Infraestructure.Service.Mailer
{
    public class EmailModel
    {
        public EmailModel(string To, string Subject, string Body)
        {
            this.To = To;
            this.Subject = Subject;
            this.Body = Body;            
        }

        public string To { get; }
        public string Subject { get; }
        public string Body { get; }
    }
}
