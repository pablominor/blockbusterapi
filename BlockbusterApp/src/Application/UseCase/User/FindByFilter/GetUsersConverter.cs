using BlockbusterApp.src.Application.UseCase.User.FindById;
using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using BlockbusterApp.src.Shared.Application.Bus.UseCase.Response;
using System.Collections.Generic;

namespace BlockbusterApp.src.Application.UseCase.User.FindByFilter
{
    public class GetUsersConverter : ResponseConverterAdapter
    {

        public GetUsersConverter():base(new FindUserResponseConverter())
        {
        }


        public GetUsersResponse<IResponse> Convert(IEnumerable<dynamic> users)
        {
            return new GetUsersResponse<IResponse>()
            {
                Users = base.Convert(users).Items()
            };
        }

    }
}
