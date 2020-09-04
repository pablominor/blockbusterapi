using BlockbusterApp.src.Application.UseCase.Film.Response;
using BlockbusterApp.src.Shared.Application.Bus.UseCase.Response;

namespace BlockbusterApp.src.Application.UseCase.Film.FindByFilter
{

    public class FindFilmsByFilterConverter : ResponseConverterAdapter
    {

        public FindFilmsByFilterConverter() : base(new FindFilmResponseConverter())
        {
        }
    }
}
