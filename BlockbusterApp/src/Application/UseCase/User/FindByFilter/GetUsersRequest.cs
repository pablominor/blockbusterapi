using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using Microsoft.AspNetCore.Http;

namespace BlockbusterApp.src.Application.UseCase.User.FindByFilter
{
    public class GetUsersRequest : AbstractRequest
    {
        public GetUsersRequest(IQueryCollection query) : base(query) { }
    }
}
