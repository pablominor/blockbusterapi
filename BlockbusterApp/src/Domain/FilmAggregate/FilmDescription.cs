using BlockbusterApp.src.Domain.FilmAggregate.Exception;
using BlockbusterApp.src.Shared.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Domain.FilmAggregate
{
    public class FilmDescription : StringValueObject
    {
        public const int MIN_LENGTH = 3;
        public const int MAX_LENGTH = 1300;

        public FilmDescription(string value) : base(value)
        {
            if (value.Length < MIN_LENGTH)
            {
                throw InvalidFilmAttributeException.FromMinLength("description", MIN_LENGTH);
            }
            if (value.Length > MAX_LENGTH)
            {
                throw InvalidFilmAttributeException.FromMaxLength("description", MAX_LENGTH);
            }
        }
    }
}
