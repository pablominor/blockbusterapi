using BlockbusterApp.src.Shared.Domain.Exception;

namespace BlockbusterApp.src.Domain.FilmAggregate.Exception
{
    public class InvalidFilmAttributeException : InvalidAttributeException
    {
        public InvalidFilmAttributeException(string message) : base(message) { }
    }
}
