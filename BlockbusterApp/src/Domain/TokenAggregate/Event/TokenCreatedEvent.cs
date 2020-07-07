using BlockbusterApp.src.Shared.Domain.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Domain.TokenAggregate.Event
{
    public class TokenCreatedEvent : DomainEvent
    {
        public TokenCreatedEvent(string aggegateId, Dictionary<string, string> body) : base(aggegateId, body)
        {

        }

        public override string Name()
        {
            return "token_created";
        }

        protected override Dictionary<string, string> Rules()
        {
            Dictionary<string, string> rules = new Dictionary<string, string>
            {
                { "hash","string"},
                { "user_id","string"},
                { "created_at","string"},
                { "updated_at","string"}
            };

            return rules;
        }
    }
}
