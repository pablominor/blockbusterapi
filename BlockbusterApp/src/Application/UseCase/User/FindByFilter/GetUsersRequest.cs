using BlockbusterApp.src.Shared.Application.Bus.UseCase.Request;
using Microsoft.AspNetCore.Http;

namespace BlockbusterApp.src.Application.UseCase.User.FindByFilter
{
    public class GetUsersRequest : AbstractRequest
    {
        public GetUsersRequest(IQueryCollection query) : base(query) { }
    }
}
