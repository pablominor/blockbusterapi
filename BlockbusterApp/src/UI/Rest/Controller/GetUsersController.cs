using BlockbusterApp.src.Application.UseCase.User.GetAll;
using BlockbusterApp.src.Shared.Infraestructure.Bus.UseCase;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.UI.Rest.Controller
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/users")]
    [ApiController]
    public class GetUsersController : Shared.UI.Rest.Controller.Controller
    {
        public GetUsersController(IUseCaseBus useCaseBus) : base(useCaseBus)
        {

        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetUsers()
        {
            GetUsersRequest request = new GetUsersRequest(HttpContext.Request.Query);
            return Dispatch(request);
        }
    }
}
