using BlockbusterApp.src.Application.UseCase.User.FindById;
using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using BlockbusterApp.src.Shared.Application.Bus.UseCase.Response;
using System.Collections.Generic;

namespace BlockbusterApp.src.Application.UseCase.User.FindByFilter
{
    public class GetUsersConverter : ConverterAdapter
    {

        public GetUsersConverter():base(new FindUserConverter())
        {
        }

        public override IResponse Convert(IEnumerable<dynamic> objects)
        {
            GetUsersResponse response = new GetUsersResponse();
            response.Users = this.GetListResponses(objects);
            return response;
        }

    }
}
