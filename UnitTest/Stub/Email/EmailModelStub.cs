using BlockbusterApp.src.Application.UseCase.Email;
using BlockbusterApp.src.Infraestructure.Service.Mailer;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTest.Stub.Email
{
    public class EmailModelStub
    {

        public const string TO = "blockbuster@mail.com";
        public const string SUBJECT = "Welcome";
        public const string BODY = "Welcome to blockbusterapp";

        public static EmailModel ByDefault()
        {
            return Create(TO, SUBJECT, BODY);            
        }

        private static EmailModel Create(string To, string Subject, string Body)
        {
            return new EmailModel(To, Subject, Body);
        }
    }
}
