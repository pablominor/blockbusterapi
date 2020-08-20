using BlockbusterApp.src.Domain.FilmAggregate.Exception;

namespace BlockbusterApp.src.Domain.FilmAggregate.Service
{
    public class CreateFilmValidator
    {
        private IFilmRepository filmRepository;
        public CreateFilmValidator(IFilmRepository filmRepository)
        {
            this.filmRepository = filmRepository;
        }

        public virtual void Validate(FilmId id, FilmName name)
        {
            var film = this.filmRepository.FindById(id);
            if (film != null)
            {
                throw FilmFoundException.FromId(id);
            }
            film = this.filmRepository.FindByName(name);
            if (film != null)
            {
                throw FilmFoundException.FromName(name);
            }
        }
    }
}
