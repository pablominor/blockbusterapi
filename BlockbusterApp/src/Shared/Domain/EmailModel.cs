using BlockbusterApp.src.Shared.Domain.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Shared.Domain
{
    public class EmailModel
    {

        private string From;
        private string To;
        private string Subject;
        private string Body;

        public EmailModel(string From, string To, string Subject, string Body)
        {
            setFrom(From);
            setTo(To);
            setSubject(Subject);
            setBody(Body);            
        }

        public string GetFrom() {
            return this.From;
        }

        public string GetTo()
        {
            return this.To;
        }

        public string GetSubject()
        {
            return this.Subject;
        }

        public string GetBody()
        {
            return this.Body;
        }

        private void setFrom(string value)
        {
            ValidateAddressFromString("from",value);
            this.From = value;
        }

        private void setTo(string value)
        {
            ValidateAddressFromString("to", value);
            this.To = value;

        }

        private void setSubject(string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                throw InvalidEmailException.FromEmpty("subject");
            }
            this.Subject = value;
        }

        private void setBody(string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                throw InvalidEmailException.FromEmpty("body");
            }
            this.Body = value;
        }

        private void ValidateAddressFromString(string name, string value)
        {
            try
            {
                new System.Net.Mail.MailAddress(value);
            }
            catch
            {
                throw InvalidEmailException.FromValue(name, value);
            }
        }
    }
}
