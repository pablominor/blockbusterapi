using BlockbusterApp.src.Application.UseCase.Product.Create;
using BlockbusterApp.src.Domain.UserAggregate;
using BlockbusterApp.src.Shared.Infraestructure.Bus.UseCase;
using BlockbusterApp.src.Shared.Infraestructure.Security.Authentication.JWT;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlockbusterApp.src.UI.Rest.Controller.Product
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/product")]
    [ApiController]
    public class CreateProductController : Shared.UI.Rest.Controller.Controller
    {

        public CreateProductController(
            IUseCaseBus useCaseBus,
            IUserProvider userProvider)
            : base(useCaseBus, userProvider)
        {

        }

        [Authorize(Roles = UserRole.ROLE_ADMIN)]
        [HttpPut(Name = nameof(CreateProduct))]
        public IActionResult CreateProduct(CreateProductRequest request)
        {
            return Dispatch(request);
        }
    }
}
