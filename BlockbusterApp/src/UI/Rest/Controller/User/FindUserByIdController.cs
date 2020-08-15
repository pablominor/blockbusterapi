using BlockbusterApp.src.Application.UseCase.User.FindById;
using BlockbusterApp.src.Domain.UserAggregate;
using BlockbusterApp.src.Shared.Infraestructure.Bus.UseCase;
using BlockbusterApp.src.Shared.Infraestructure.Security.Authentication.JWT;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace BlockbusterApp.src.UI.Rest.Controller.User
{
    [ExcludeFromCodeCoverage]
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/user")]
    [ApiController]
    public class FindUserByIdController : Shared.UI.Rest.Controller.Controller
    {
        public FindUserByIdController(
            IUseCaseBus useCaseBus,
            IUserProvider userProvider) 
            : base(useCaseBus, userProvider)
        {

        }
        
        [Authorize(Roles = UserRole.ROLE_USER)]
        [HttpGet]
        public IActionResult FindUserById()
        {
            FindUserByIdRequest request = new FindUserByIdRequest(id: GetUserId());
            return Dispatch(request);
        }
    }
}
