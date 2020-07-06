using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using BlockbusterApp.src.Shared.Infraestructure.Bus.Middleware.Exception;
using BlockbusterApp.src.Shared.Infraestructure.Bus.UseCase;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Shared.UI.Rest.Controller
{
    public abstract class Controller : ControllerBase
    {
        private IUseCaseBus useCaseBus;
        public Controller(IUseCaseBus useCaseBus)
        {
            this.useCaseBus = useCaseBus;
        }


        protected IActionResult Dispatch(IRequest request)
        {
            IResponse response = this.useCaseBus.Dispatch(request);

            if (response is ExceptionResponse && ((ExceptionResponse)response).Code == "400")
            {
                return BadRequest(response);
            }
            else if (response is ExceptionResponse && ((ExceptionResponse)response).Code == "500")
            {
                return StatusCode(500, response);
            }
            return Ok(response);
        }
    }
}
