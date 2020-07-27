using BlockbusterApp.src.Application.UseCase.Email.SendUserWelcome;
using BlockbusterApp.src.Infraestructure.Service.Mailer;
using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using BlockbusterApp.src.Shared.Domain;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using UnitTest.Stub.Email;
using UnitTest.Stub.Request;

namespace UnitTest.Application.UseCase.Email
{
    [TestFixture]
    public class SendUseWelcomeEmailUseCaseTest
    {
        [Test]
        public void ItShouldCallCollaborators()
        {
            SendUserWelcomeEmailRequest request = SendUserWelcomeEmailRequestStub.ByDefault();
            EmailModel emailModel = EmailModelStub.ByDefault();
            Mock<IConfiguration> configuration = new Mock<IConfiguration>();
            Mock<WelcomeEmailModelFactory> welcomeEmailModelFactory = new Mock<WelcomeEmailModelFactory>(configuration.Object);
            welcomeEmailModelFactory.Setup(o => o.Create(request.Email,request.FirstName,request.LastName)).Returns(emailModel);
            Mock<IMailer> mailer = new Mock<IMailer>();
            mailer.Setup(o => o.Send(It.IsAny<EmailModel>()));
            Mock<EmptyResponseConverter> emptyResponseConverter = new Mock<EmptyResponseConverter>();
            emptyResponseConverter.Setup(o => o.Convert());
            SendUserWelcomeEmailUseCase useCase = new SendUserWelcomeEmailUseCase(
                welcomeEmailModelFactory.Object,
                mailer.Object,
                emptyResponseConverter.Object);

            useCase.Execute(request);

            welcomeEmailModelFactory.VerifyAll();
            mailer.VerifyAll();
            emptyResponseConverter.VerifyAll();
        }
    }
}
