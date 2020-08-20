using BlockbusterApp.src.Domain.FilmAggregate;
using BlockbusterApp.src.Domain.FilmAggregate.Service;
using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Application.UseCase.Film.Create
{
    public class CreateFilmUseCase : IUseCase
    {
        private IFilmFactory filmFactory;
        private IFilmRepository filmRepository;
        private EmptyResponseConverter converter;
        private CreateFilmValidator validator;

        public CreateFilmUseCase(
            IFilmFactory filmFactory,
            IFilmRepository filmRepository,
            EmptyResponseConverter converter,
            CreateFilmValidator validator)
        {
            this.filmFactory = filmFactory;
            this.filmRepository = filmRepository;
            this.converter = converter;
            this.validator = validator;
        }

        public IResponse Execute(IRequest req)
        {
            CreateFilmRequest request = req as CreateFilmRequest;

            Domain.FilmAggregate.Film film = filmFactory.Create(request.Id, request.Name,request.Description,request.Price,request.CategoryId);

            this.validator.Validate(film.id, film.name);

            this.filmRepository.Add(film);

            return this.converter.Convert();
        }
    }
}
