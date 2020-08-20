namespace BlockbusterApp.src.Domain.FilmAggregate
{
    public interface IFilmFactory
    {
        Film Create(string id, string name, string description, decimal price, string categoryId);
    }
}
