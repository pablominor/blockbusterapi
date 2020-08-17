using BlockbusterApp.src.Application.UseCase.Token.Create;
using BlockbusterApp.src.Shared.Infraestructure.Bus.UseCase;
using BlockbusterApp.src.Shared.Infraestructure.Security.Authentication.JWT;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace BlockbusterApp.src.UI.Rest.Controller.Token
{
    
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/token")]
    [ApiController]
    public class CreateTokenController : Shared.UI.Rest.Controller.Controller
    {
        public CreateTokenController(
            IUseCaseBus useCaseBus,
            IUserProvider userProvider) 
            : base(useCaseBus,userProvider)
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
