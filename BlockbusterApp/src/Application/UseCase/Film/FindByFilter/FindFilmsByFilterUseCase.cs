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
        private IProductRepository productRepository;
        private FindFilmsByFilterConverter converter;

        public FindFilmsByFilterUseCase(
            IProductRepository filmRepository, 
            FindFilmsByFilterConverter converter)
        {
            this.productRepository = filmRepository;
            this.converter = converter;
        }

        public IResponse Execute(IRequest req)
        {
            FindFilmsByFilterRequest request = req as FindFilmsByFilterRequest;

            List<Domain.ProductAggregate.Product> films = this.productRepository.FindByFilter(request.Page(), request.Filter());

            return this.converter.Convert(films);
        }
    }
}
