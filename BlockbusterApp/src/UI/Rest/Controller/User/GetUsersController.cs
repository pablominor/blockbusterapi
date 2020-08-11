using BlockbusterApp.src.Application.UseCase.User.FindByFilter;
using BlockbusterApp.src.Domain.UserAggregate;
using BlockbusterApp.src.Shared.Infraestructure.Bus.UseCase;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace BlockbusterApp.src.UI.Rest.Controller.User
{
    [ExcludeFromCodeCoverage]
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/users")]
    [ApiController]
    public class GetUsersController : Shared.UI.Rest.Controller.Controller
    {
        public GetUsersController(IUseCaseBus useCaseBus) : base(useCaseBus)
        {

        }
        
        [Authorize(Roles = UserRole.ROLE_ADMIN)]
        [HttpGet]
        public IActionResult GetUsers()
        {
            GetUsersRequest request = new GetUsersRequest(HttpContext.Request.Query);
            return Dispatch(request);
        }
    }
}
