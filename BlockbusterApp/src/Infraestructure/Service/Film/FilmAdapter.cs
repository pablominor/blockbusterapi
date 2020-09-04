using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Infraestructure.Service.Film
{
    public class FilmAdapter
    {

        private IFilmFacade filmFacade;
        private IFilmTranslator filmTranslator;

        public FilmAdapter(IFilmFacade filmFacade, IFilmTranslator filmTranslator)
        {
            this.filmFacade = filmFacade;
            this.filmTranslator = filmTranslator;
        }

        public virtual Domain.ProductAggregate.Product FindFilmFromName(string name)
        {
            var film = this.filmFacade.FindFilmFromName(name);
            return this.filmTranslator.FromRepresentationToFilm(film);
        }

    }
}
