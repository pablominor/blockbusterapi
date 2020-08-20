using BlockbusterApp.src.Shared.Domain;
using System;

namespace BlockbusterApp.src.Domain.FilmAggregate
{
    public class FilmCreatedAt : DateTimeValueObject
    {
        public FilmCreatedAt(DateTime value) : base(value)
        {

        }
    }
}
