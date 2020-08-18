using BlockbusterApp.src.Application.Event.User;
using BlockbusterApp.src.Domain.UserAggregate;
using BlockbusterApp.src.Shared.Infraestructure.Bus.UseCase;
using Moq;
using NUnit.Framework;
using UnitTest.Shared.Application.Bus.UseCase;

namespace UnitTest.Application.Event.User
{
    [TestFixture]
    public class SendWelcomeEmailWhenUserSignedUpEventHandlerTest
    {

        [Test]
        public void ItShouldCallCollaborators()
        {
            Mock<IUseCaseBus> useCaseBus = UseCaseBusMockGenerator.CreateUseCaseBusThatDispatchAnyRequest();
            SendWelcomeEmailWhenUserSignedUpEventHandler sendWelcomeEmailEventHandler = new SendWelcomeEmailWhenUserSignedUpEventHandler(useCaseBus.Object);

            sendWelcomeEmailEventHandler.Handle(SendWelcomeEmailDomainEventStub.ByDefault());

            useCaseBus.VerifyAll();
        }
    }
}
