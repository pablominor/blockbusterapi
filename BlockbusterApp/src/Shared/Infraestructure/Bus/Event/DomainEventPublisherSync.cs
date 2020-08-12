using BlockbusterApp.src.Shared.Domain.Event;
using System.Diagnostics.CodeAnalysis;

namespace BlockbusterApp.src.Shared.Infraestructure.Bus.Event
{
    [ExcludeFromCodeCoverage]
    public class DomainEventPublisherSync : IDomainEventPublisher
    {
        private IEventBus eventBus;

        public DomainEventPublisherSync(IEventBus eventBus)
        {
            this.eventBus = eventBus;
        }

        public void Publish(DomainEvent domainEvent)
        {
            this.eventBus.Dispatch(domainEvent);
        }
    }
}
