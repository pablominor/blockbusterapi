using BlockbusterApp.src.Shared.Domain;
using System;

namespace BlockbusterApp.src.Domain.FilmAggregate
{
    public class FilmUpdatedAt : DateTimeValueObject
    {
        public FilmUpdatedAt(DateTime value) : base(value)
        {

        }
    }
}
