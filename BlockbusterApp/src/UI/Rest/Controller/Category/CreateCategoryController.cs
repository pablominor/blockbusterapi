using BlockbusterApp.src.Application.UseCase.Category.Create;
using BlockbusterApp.src.Domain.UserAggregate;
using BlockbusterApp.src.Shared.Infraestructure.Bus.UseCase;
using BlockbusterApp.src.Shared.Infraestructure.Security.Authentication.JWT;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlockbusterApp.src.UI.Rest.Controller.Category
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/category")]
    [ApiController]
    public class CreateCategoryController : Shared.UI.Rest.Controller.Controller
    {

        public CreateCategoryController(
            IUseCaseBus useCaseBus,
            IUserProvider userProvider)
            : base(useCaseBus, userProvider)
        {

        }

        [Authorize(Roles = UserRole.ROLE_ADMIN)]
        [HttpPut(Name = nameof(CreateCategory))]
        public IActionResult CreateCategory(CreateCategoryRequest request)
        {
            return Dispatch(request);
        }

    }
}
