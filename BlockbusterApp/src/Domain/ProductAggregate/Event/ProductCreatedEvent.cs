using BlockbusterApp.src.Shared.Domain.Event;
using System.Collections.Generic;

namespace BlockbusterApp.src.Domain.ProductAggregate.Event
{
    public class ProductCreatedEvent : DomainEvent
    {
        public ProductCreatedEvent(string aggegateId, Dictionary<string, string> body) : base(aggegateId, body)
        {

        }

        public override string Name()
        {
            return "product_created";
        }

        protected override Dictionary<string, string> Rules()
        {
            Dictionary<string, string> rules = new Dictionary<string, string>
            {
                { "id","string"},
                { "name","string"},
                { "description","string"},
                { "price","string"},
                { "category_id","string"},
                { "created_at","string"},
                { "updated_at","string"}
            };

            return rules;
        }
    }
}
