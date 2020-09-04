using BlockbusterApp.src.Application.UseCase.Category.FindByName;
using BlockbusterApp.src.Application.UseCase.Category.Response;
using BlockbusterApp.src.Domain.ProductAggregate;
using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using BlockbusterApp.src.Shared.Infraestructure.Bus.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Infraestructure.Service.Film.CraftCodeAPI
{
    public class CraftCodeAPIFilmTranslator : IFilmTranslator
    {
        private const decimal DEAULT_PRICE = 10;
        private IUseCaseBus useCaseBus;
        private IProductFactory filmFactory;

        public CraftCodeAPIFilmTranslator(IUseCaseBus useCaseBus, IProductFactory filmFactory)
        {
            this.useCaseBus = useCaseBus;
            this.filmFactory = filmFactory;
        }

        public Domain.ProductAggregate.Product FromRepresentationToFilm(dynamic film)
        {
            string categoryName = film.Genre.Split(',')[0];
            IResponse response = useCaseBus.Dispatch(new FindCategoryByNameRequest(categoryName));
            CategoryResponse categoryResponse = response as CategoryResponse;

            Guid uuid = Guid.NewGuid();            

            Domain.ProductAggregate.Product newFilm = this.filmFactory.Create(uuid.ToString(),film.Title,film.Plot,DEAULT_PRICE, categoryResponse.Id);

            return newFilm;
        }
    }
}
