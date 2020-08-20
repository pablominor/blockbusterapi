using BlockbusterApp.src.Domain.FilmAggregate.Exception;
using BlockbusterApp.src.Shared.Domain;

namespace BlockbusterApp.src.Domain.FilmAggregate
{
    public class FilmName : StringValueObject
    {
        public const int MIN_LENGTH = 3;
        public const int MAX_LENGTH = 30;

        public FilmName(string value) : base(value)
        {
            if (value.Length < MIN_LENGTH)
            {
                throw InvalidFilmAttributeException.FromMinLength("name", MIN_LENGTH);
            }
            if (value.Length > MAX_LENGTH)
            {
                throw InvalidFilmAttributeException.FromMaxLength("name", MAX_LENGTH);
            }
        }
    }
}
