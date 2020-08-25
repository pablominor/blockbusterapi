using BlockbusterApp.src.Application.UseCase.Product.Response;
using BlockbusterApp.src.Shared.Application.Bus.UseCase.Response;

namespace BlockbusterApp.src.Application.UseCase.Product.FindByFilter
{
    public class FindProductsByFilterConverter : ResponseConverterAdapter
    {

        public FindProductsByFilterConverter() : base(new FindProductResponseConverter())
        {
        }
    }
}
