﻿using BlockbusterApp.src.Shared.Domain.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Shared.Infraestructure.Bus.Event
{
    public interface IDomainEventPublisher
    {
        void Publish(DomainEvent domainEvent);
    }
}
