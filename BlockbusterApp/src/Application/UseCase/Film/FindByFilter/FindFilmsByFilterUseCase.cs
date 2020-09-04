using BlockbusterApp.src.Application.UseCase.Product.Create;
using BlockbusterApp.src.Domain.ProductAggregate;
using BlockbusterApp.src.Infraestructure.Service.Film;
using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using BlockbusterApp.src.Shared.Infraestructure.Bus.UseCase;
using System.Collections.Generic;

namespace BlockbusterApp.src.Application.UseCase.Film.FindByFilter
{
    public class FindFilmsByFilterUseCase : IUseCase
    {
        private IProductRepository filmRepository;
        private FindFilmsByFilterConverter converter;
        private FilmAdapter filmAdapter;
        private IUseCaseBus useCaseBus;
        private FilmsToBeSearchedAdapter filmsToBeSearchedAdapter;

        public FindFilmsByFilterUseCase(
            IProductRepository filmRepository, 
            FindFilmsByFilterConverter converter, 
            FilmAdapter filmAdapter,
            IUseCaseBus useCaseBus,
            FilmsToBeSearchedAdapter filmsToBeSearchedAdapter)
        {
            this.filmRepository = filmRepository;
            this.converter = converter;
            this.filmAdapter = filmAdapter;
            this.useCaseBus = useCaseBus;
            this.filmsToBeSearchedAdapter = filmsToBeSearchedAdapter;
        }

        public IResponse Execute(IRequest req)
        {
            FindFilmsByFilterRequest request = req as FindFilmsByFilterRequest;

            List<Domain.ProductAggregate.Product> films = this.filmRepository.FindByFilter(request.Page(), request.Filter());

            List<string> namesFromFilmsThatShouldBeSearched = filmsToBeSearchedAdapter.GetNamesFromFilmsThatShouldBeSearched(request.Names(), films);

            foreach (string filmName in namesFromFilmsThatShouldBeSearched)
            {
                Domain.ProductAggregate.Product film = this.filmAdapter.FindFilmFromName(filmName);
                if (film == null) continue;
                films.Add(film);
                this.useCaseBus.Dispatch(new CreateProductRequest(
                    film.id.GetValue(), 
                    film.name.GetValue(), 
                    film.description.GetValue(), 
                    film.price.GetValue(), 
                    film.categoryId.GetValue()));
            }

            return this.converter.Convert(films);
        }


    }
}
