using BlockbusterApp.src.Application.UseCase.Email;
using BlockbusterApp.src.Application.UseCase.Email.SendUserWelcome;
using BlockbusterApp.src.Shared.Domain;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using System;
using UnitTest.Stub.Request;

namespace UnitTest.Application.UseCase.Email
{
    [TestFixture]
    public class WelcomeEmailModelFactoryTest
    {
        [Test]
        public void ItShouldCallCollaborators()
        {
            SendUserWelcomeEmailRequest request = CreateSendUserWelcomeEmailRequest();
            Mock<IConfiguration> configuration = CreateConfigurationMock();
            WelcomeEmailModelFactory welcomeEmailModelFactory = CreateWelcomeEmailModelFactory(configuration.Object);

            var res = welcomeEmailModelFactory.Create(request.Email, request.FirstName, request.LastName);

            configuration.VerifyAll();            
        }

        [Test]
        public void ItShouldCreateAnEmailModel()
        {
            SendUserWelcomeEmailRequest request = CreateSendUserWelcomeEmailRequest();
            Mock<IConfiguration> configuration = CreateConfigurationMock();
            WelcomeEmailModelFactory welcomeEmailModelFactory = CreateWelcomeEmailModelFactory(configuration.Object);
            string fullName = request.FirstName + " " + request.LastName;

            var res = welcomeEmailModelFactory.Create(request.Email, request.FirstName, request.LastName);

            Assert.IsInstanceOf<EmailModel>(res);
            Assert.AreEqual(res.GetFrom(), "pablo3informatica@gmail.com");
            Assert.AreEqual(res.GetTo(), request.Email);
            Assert.AreEqual(res.GetSubject(), "Welcome email");
            Assert.AreEqual(res.GetBody(), String.Format("Gracias por registrarte {0}. Recuerda que para iniciar sesión en nuestra aplicación debe usar su email.", fullName));
        }

        private SendUserWelcomeEmailRequest CreateSendUserWelcomeEmailRequest()
        {
            return SendUserWelcomeEmailRequestStub.ByDefault();
        }

        private Mock<IConfiguration> CreateConfigurationMock()
        {
            Mock<IConfigurationSection> welcomeEmailConfSection = new Mock<IConfigurationSection>();
            welcomeEmailConfSection.Setup(o => o.GetSection("From").Value).Returns("pablo3informatica@gmail.com");
            welcomeEmailConfSection.Setup(o => o.GetSection("Subject").Value).Returns("Welcome email");
            Mock<IConfiguration> configuration = new Mock<IConfiguration>();
            configuration.Setup(a => a.GetSection(It.Is<string>(s => s == "WelcomeEmail"))).Returns(welcomeEmailConfSection.Object);
            return configuration;
        }

        private WelcomeEmailModelFactory CreateWelcomeEmailModelFactory(IConfiguration configuration)
        {
            return new WelcomeEmailModelFactory(configuration);
        }
    }
}
