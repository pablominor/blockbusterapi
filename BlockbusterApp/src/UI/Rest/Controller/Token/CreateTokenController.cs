using BlockbusterApp.src.Application.UseCase.Token;
using BlockbusterApp.src.Shared.Infraestructure.Bus.UseCase;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlockbusterApp.src.UI.Rest.Controller.Token
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/token")]
    [ApiController]
    public class CreateTokenController : Shared.UI.Rest.Controller.Controller
    {
        public CreateTokenController(IUseCaseBus useCaseBus) :base(useCaseBus)
        {

        }

        [AllowAnonymous]
        [HttpPut(Name = nameof(Create))]
        public IActionResult Create(CreateTokenRequest request)
        {
            return Dispatch(request);
        }
    }
}
