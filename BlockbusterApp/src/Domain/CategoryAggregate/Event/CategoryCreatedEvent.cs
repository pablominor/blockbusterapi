using BlockbusterApp.src.Shared.Domain.Event;
using System.Collections.Generic;

namespace BlockbusterApp.src.Domain.CategoryAggregate.Event
{
    public class CategoryCreatedEvent : DomainEvent
    {
        public CategoryCreatedEvent(string aggegateId, Dictionary<string, string> body) : base(aggegateId, body)
        {

        }

        public override string Name()
        {
            return "category_created";
        }

        protected override Dictionary<string, string> Rules()
        {
            Dictionary<string, string> rules = new Dictionary<string, string>
            {
                { "id","string"},
                { "name","string"},
                { "created_at","string"},
                { "updated_at","string"}
            };

            return rules;
        }
    }
}
