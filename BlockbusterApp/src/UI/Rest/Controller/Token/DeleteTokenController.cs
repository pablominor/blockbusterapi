using BlockbusterApp.src.Application.UseCase.Token.Delete;
using BlockbusterApp.src.Domain.UserAggregate;
using BlockbusterApp.src.Shared.Infraestructure.Bus.UseCase;
using BlockbusterApp.src.Shared.Infraestructure.Security.Authentication.JWT;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlockbusterApp.src.UI.Rest.Controller.Token
{

    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/token")]
    [ApiController]
    public class DeleteTokenController : Shared.UI.Rest.Controller.Controller
    {
        public DeleteTokenController(
            IUseCaseBus useCaseBus,
            IUserProvider userProvider) 
            : base(useCaseBus,userProvider)
        {

        }

        [Authorize(Roles = UserRole.ROLE_ADMIN_OR_USER)]
        [HttpDelete(Name = nameof(Delete))]
        public IActionResult Delete(DeleteTokenRequest request)
        {
            request.tokenUserId = GetUserId();
            return Dispatch(request);
        }
    }
}
