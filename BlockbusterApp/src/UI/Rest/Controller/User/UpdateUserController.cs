using BlockbusterApp.src.Application.UseCase.User.Update;
using BlockbusterApp.src.Domain.UserAggregate;
using BlockbusterApp.src.Shared.Infraestructure.Bus.UseCase;
using BlockbusterApp.src.Shared.Infraestructure.Security.Authentication.JWT;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlockbusterApp.src.UI.Rest.Controller.User
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/user")]
    [ApiController]
    public class UpdateUserController : Shared.UI.Rest.Controller.Controller
    {
        public UpdateUserController(
            IUseCaseBus useCaseBus,
            IUserProvider userProvider)
            : base(useCaseBus, userProvider)
        {

        }

        [Authorize(Roles = UserRole.ROLE_USER)]
        [HttpPut(Name = nameof(Update))]
        public IActionResult Update(UpdateUserRequest request)
        {
            request.Id = GetUserId();
            return Dispatch(request);
        }
    }
}
