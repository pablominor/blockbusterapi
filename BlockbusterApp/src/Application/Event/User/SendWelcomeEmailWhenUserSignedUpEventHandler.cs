﻿using BlockbusterApp.src.Application.UseCase.Email.SendUserWelcome;
using BlockbusterApp.src.Shared.Application.Event;
using BlockbusterApp.src.Shared.Domain.Event;
using BlockbusterApp.src.Shared.Infraestructure.Bus.UseCase;
using System.Collections.Generic;

namespace BlockbusterApp.src.Application.Event.User
{
    public class SendWelcomeEmailWhenUserSignedUpEventHandler : IEventHandler
    {
        private IUseCaseBus useCaseBus;

        public SendWelcomeEmailWhenUserSignedUpEventHandler(IUseCaseBus useCaseBus) 
        {
            this.useCaseBus = useCaseBus;
        }

        public void Handle(DomainEvent domainEvent)
        {
            Dictionary<string,string> body = domainEvent.Body();

            this.useCaseBus.Dispatch(new SendUserWelcomeEmailRequest
                (body["email"],
                body["firstname"],
                body["lastname"]
            ));
        }
    }
}
