using BlockbusterApp.src.Shared.Domain;

namespace BlockbusterApp.src.Domain.FilmAggregate
{
    public class FilmId : UUID
    {
        public FilmId(string value) : base(value)
        {

        }
    }
}
