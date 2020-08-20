using BlockbusterApp.src.Shared.Domain;
using System;

namespace BlockbusterApp.src.Domain.TokenAggregate
{
    public class TokenCreatedAt : DateTimeValueObject
    {
        public TokenCreatedAt(DateTime value) : base(value)
        {

        }
    }
}
