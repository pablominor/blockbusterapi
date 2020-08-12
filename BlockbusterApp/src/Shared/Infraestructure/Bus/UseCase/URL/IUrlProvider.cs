using BlockbusterApp.src.Shared.Infraestructure.Bus.UseCase.URL.Entity;

namespace BlockbusterApp.src.Shared.Infraestructure.Bus.UseCase.URL
{
    public interface IUrlProvider
    {
        UrlHelper GetUrlHelper();
    }
}
