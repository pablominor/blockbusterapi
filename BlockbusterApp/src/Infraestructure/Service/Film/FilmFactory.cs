using BlockbusterApp.src.Domain.FilmAggregate;
using BlockbusterApp.src.Shared.Infraestructure.Bus.UseCase;


namespace BlockbusterApp.src.Infraestructure.Service.Film
{
    public class FilmFactory : IFilmFactory
    {
        private IUseCaseBus useCaseBus;
        public FilmFactory(IUseCaseBus useCaseBus)
        {
            this.useCaseBus = useCaseBus;
        }


        public Domain.FilmAggregate.Film Create(string id, string name, string description, decimal price, string categoryId)
        {
            FilmId filmId = new FilmId(id);
            FilmName filmName = new FilmName(name);
            FilmDescription filmDescription = new FilmDescription(description);
            FilmPrice filmPrice = new FilmPrice(price);

            //IResponse res = this.useCaseBus.Dispatch(new FindCategoryByIdRequest(categoryId));
            FilmCategoryId filmCategoryId = new FilmCategoryId(categoryId);

            return Domain.FilmAggregate.Film.Create(
                filmId,
                filmName,
                filmDescription,
                filmPrice,
                filmCategoryId);
        }
    }
}
