using BlockbusterApp.src.Application.UseCase.Email;
using BlockbusterApp.src.Infraestructure.Service.Mailer;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using UnitTest.Stub.Request;

namespace UnitTest.Application.UseCase.Email
{
    [TestFixture]
    public class WelcomeEmailModelFactoryTest
    {
        [Test]
        public void ItShouldCreateAnEmailModel()
        {

            SendUserWelcomeEmailRequest request = SendUserWelcomeEmailRequestStub.ByDefault();
            WelcomeEmailModelFactory welcomeEmailModelFactory = new WelcomeEmailModelFactory();
            string fullName = request.FirstName + " " + request.LastName;

            var res = welcomeEmailModelFactory.Create(request);

            Assert.IsInstanceOf<EmailModel>(res);
            Assert.AreEqual(res.To, request.Email);
            Assert.AreEqual(res.Subject, WelcomeEmailModelFactory.WELCOME_SUBJECT);
            Assert.AreEqual(res.Body, String.Format("Gracias por registrarte {0}. Recuerda que para iniciar sesión en nuestra aplicación debe usar su email.", fullName));
        }
    }
}
