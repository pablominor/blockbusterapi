using BlockbusterApp.src.Application.UseCase.User.FindById;
using BlockbusterApp.src.Domain.UserAggregate;
using BlockbusterApp.src.Shared.Infraestructure.Bus.UseCase;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlockbusterApp.src.UI.Rest.Controller.User
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/user")]
    [ApiController]
    public class FindUserByIdController : Shared.UI.Rest.Controller.Controller
    {
        public FindUserByIdController(IUseCaseBus useCaseBus) : base(useCaseBus)
        {

        }
        
        [Authorize(Roles = UserRole.ROLE_USER)]
        [HttpGet]
        public IActionResult FindUserById(FindUserByIdRequest request)
        {
            return Dispatch(request);
        }
    }
}
