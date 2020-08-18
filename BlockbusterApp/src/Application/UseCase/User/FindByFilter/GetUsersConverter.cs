using BlockbusterApp.src.Application.UseCase.User.Response;
using BlockbusterApp.src.Shared.Application.Bus.UseCase.Response;

namespace BlockbusterApp.src.Application.UseCase.User.FindByFilter
{
    public class GetUsersConverter : ResponseConverterAdapter
    {

        public GetUsersConverter():base(new FindUserResponseConverter())
        {
        }

    }
}
