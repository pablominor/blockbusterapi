namespace BlockbusterApp.src.Domain.FilmAggregate
{
    public interface IFilmRepository
    {
        void Add(Film film);
        Film FindById(FilmId id);
        Film FindByName(FilmName name);
    }
}
