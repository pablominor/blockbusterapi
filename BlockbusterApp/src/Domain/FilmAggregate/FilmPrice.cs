using BlockbusterApp.src.Domain.FilmAggregate.Exception;
using BlockbusterApp.src.Shared.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Domain.FilmAggregate
{
    public class FilmPrice : DecimalValueObject
    {
        public const int MIN_LENGTH = 3;
        public const int MAX_LENGTH = 30;

        public FilmPrice(decimal value) : base(value)
        {
            if (value == 0 || value < 0)
            {
                throw InvalidFilmAttributeException.FromValue("description", value.ToString());
            }            
        }
    }
}
