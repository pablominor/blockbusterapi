using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Infraestructure.Service.Film
{
    public interface IFilmTranslator
    {
        Domain.ProductAggregate.Product FromRepresentationToFilm(dynamic film);

    }
}
