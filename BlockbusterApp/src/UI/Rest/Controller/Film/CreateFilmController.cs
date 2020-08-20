using BlockbusterApp.src.Application.UseCase.Film.Create;
using BlockbusterApp.src.Domain.UserAggregate;
using BlockbusterApp.src.Shared.Infraestructure.Bus.UseCase;
using BlockbusterApp.src.Shared.Infraestructure.Security.Authentication.JWT;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlockbusterApp.src.UI.Rest.Controller.Film
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/film")]
    [ApiController]
    public class CreateFilmController : Shared.UI.Rest.Controller.Controller
    {

        public CreateFilmController(
            IUseCaseBus useCaseBus,
            IUserProvider userProvider)
            : base(useCaseBus, userProvider)
        {

        }

        [Authorize(Roles = UserRole.ROLE_ADMIN)]
        [HttpPut(Name = nameof(CreateFilm))]
        public IActionResult CreateFilm(CreateFilmRequest request)
        {
            return Dispatch(request);
        }
    }
}
