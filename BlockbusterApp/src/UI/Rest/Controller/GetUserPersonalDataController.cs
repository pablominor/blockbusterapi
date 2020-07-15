using BlockbusterApp.src.Application.UseCase.User.GetUserPersonalData;
using BlockbusterApp.src.Shared.Infraestructure.Bus.UseCase;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlockbusterApp.src.UI.Rest.Controller
{
    //[Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/user")]
    [ApiController]
    public class GetUserPersonalDataController : Shared.UI.Rest.Controller.Controller
    {
        public GetUserPersonalDataController(IUseCaseBus useCaseBus) : base(useCaseBus)
        {

        }
        
        //[Authorize(Roles = UserRole.ROLE_ADMIN)]
        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetUserPersonalData(GetUserPersonalDataRequest request)
        {
            return Dispatch(request);
        }
    }
}
