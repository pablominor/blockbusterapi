using BlockbusterApp.src.Application.UseCase.Product.FindByFilter;
using BlockbusterApp.src.Domain.UserAggregate;
using BlockbusterApp.src.Shared.Infraestructure.Bus.UseCase;
using BlockbusterApp.src.Shared.Infraestructure.Security.Authentication.JWT;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlockbusterApp.src.UI.Rest.Controller.Product
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/products")]
    [ApiController]
    public class FindProductsByFilterController : Shared.UI.Rest.Controller.Controller
    {
        public FindProductsByFilterController(
            IUseCaseBus useCaseBus,
            IUserProvider userProvider)
            : base(useCaseBus, userProvider)
        {

        }

        [Authorize(Roles = UserRole.ROLE_ADMIN)]
        [HttpGet]
        public IActionResult GetUsers()
        {
            FindProductsByFilterRequest request = new FindProductsByFilterRequest(HttpContext.Request.Query);
            return Dispatch(request);
        }
    }
}
