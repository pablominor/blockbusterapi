using BlockbusterApp.src.Domain.FilmAggregate.Exception;
using BlockbusterApp.src.Shared.Domain;

namespace BlockbusterApp.src.Domain.FilmAggregate
{
    public class FilmPrice : DecimalValueObject
    {
        public FilmPrice(decimal value) : base(value)
        {
            if (value == 0 || value < 0)
            {
                throw InvalidFilmAttributeException.FromValue("price", value.ToString());
            }            
        }
    }
}
