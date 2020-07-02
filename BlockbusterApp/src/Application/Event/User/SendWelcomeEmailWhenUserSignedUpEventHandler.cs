using BlockbusterApp.src.Application.UseCase.Email;
using BlockbusterApp.src.Shared.Application.Event;
using BlockbusterApp.src.Shared.Domain.Event;
using BlockbusterApp.src.Shared.Infraestructure.Bus.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Application.Event.User
{
    public class SendWelcomeEmailWhenUserSignedUpEventHandler : IEventHandler
    {
        private IUseCaseBus _useCaseBus;

        public SendWelcomeEmailWhenUserSignedUpEventHandler(IUseCaseBus useCaseBus) 
        {
            _useCaseBus = useCaseBus;
        }

        public void Handle(DomainEvent domainEvent)
        {
            Dictionary<string,string> body = domainEvent.Body();

            _useCaseBus.Dispatch(new SendUserWelcomeEmailRequest
                (body["email"],
                body["firstname"],
                body["lastname"]
            ));
        }
    }
}
