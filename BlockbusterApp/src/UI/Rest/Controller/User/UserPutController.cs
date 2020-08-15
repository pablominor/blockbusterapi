using BlockbusterApp.src.Application.UseCase.User.SignUP;
using BlockbusterApp.src.Shared.Infraestructure.Bus.UseCase;
using BlockbusterApp.src.Shared.Infraestructure.Security.Authentication.JWT;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace BlockbusterApp.src.UI.Rest.Controller.User
{
    [ExcludeFromCodeCoverage]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/users")]
    [ApiController]
    public class UserPutController : Shared.UI.Rest.Controller.Controller
    {
        public UserPutController(
            IUseCaseBus useCaseBus,
            IUserProvider userProvider) 
            : base(useCaseBus,userProvider)
        {

        }

        [AllowAnonymous]
        [HttpPut(Name = nameof(SignUp))]
        public IActionResult SignUp(SignUpUserRequest request)
        {
            return Dispatch(request);
        }
    }
}
