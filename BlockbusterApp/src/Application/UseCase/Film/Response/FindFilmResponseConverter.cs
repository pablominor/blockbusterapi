using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using BlockbusterApp.src.Shared.Application.Bus.UseCase.Response;

namespace BlockbusterApp.src.Application.UseCase.Film.Response
{
    public class FindFilmResponseConverter : ResponseConverter
    {
        public FindFilmResponseConverter() { }

        public virtual IResponse Convert(dynamic item)
        {
            Domain.ProductAggregate.Product film = item as Domain.ProductAggregate.Product;

            string id = film.id.GetValue();
            string name = film.name.GetValue();
            string description = film.description.GetValue();
            decimal price = film.price.GetValue();
            string categoryId = film.categoryId.GetValue();
            FindFilmResponse response = new FindFilmResponse
            {
                Id = id,
                Name = name,
                Description = description,
                Price = price,
                CategoryId = categoryId
            };

            return response;
        }
    }
}
