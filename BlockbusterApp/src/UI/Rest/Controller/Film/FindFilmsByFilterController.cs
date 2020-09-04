using BlockbusterApp.src.Application.UseCase.Film.FindByFilter;
using BlockbusterApp.src.Domain.UserAggregate;
using BlockbusterApp.src.Shared.Infraestructure.Bus.UseCase;
using BlockbusterApp.src.Shared.Infraestructure.Security.Authentication.JWT;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.UI.Rest.Controller.Film
{

    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/films")]
    [ApiController]
    public class FindFilmsByFilterController : Shared.UI.Rest.Controller.Controller
    {
        public FindFilmsByFilterController(
            IUseCaseBus useCaseBus,
            IUserProvider userProvider)
            : base(useCaseBus, userProvider)
        {

        }

        [Authorize(Roles = UserRole.ROLE_USER)]
        [HttpGet]
        public IActionResult GetFilms()
        {
            FindFilmsByFilterRequest request = new FindFilmsByFilterRequest(HttpContext.Request.Query);
            return Dispatch(request);
        }
    }
}
