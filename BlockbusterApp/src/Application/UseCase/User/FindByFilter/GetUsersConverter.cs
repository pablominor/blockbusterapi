using BlockbusterApp.src.Application.UseCase.User.FindById;
using BlockbusterApp.src.Shared.Application.Bus.UseCase.Response;

namespace BlockbusterApp.src.Application.UseCase.User.FindByFilter
{
    public class GetUsersConverter : ConverterAdapter
    {

        public GetUsersConverter():base(new FindUserConverter())
        {
        }
       
    }
}
