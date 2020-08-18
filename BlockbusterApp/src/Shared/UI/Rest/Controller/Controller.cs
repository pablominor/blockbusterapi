using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using BlockbusterApp.src.Shared.Application.Bus.UseCase.Response;
using BlockbusterApp.src.Shared.Infraestructure.Bus.Middleware.Exception;
using BlockbusterApp.src.Shared.Infraestructure.Bus.UseCase;
using BlockbusterApp.src.Shared.Infraestructure.Security.Authentication.JWT;
using JsonApiSerializer;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BlockbusterApp.src.Shared.UI.Rest.Controller
{

    public abstract class Controller : ControllerBase
    {
        private IUseCaseBus useCaseBus;
        private IUserProvider userProvider;

        public Controller(IUseCaseBus useCaseBus,IUserProvider userProvider)
        {
            this.useCaseBus = useCaseBus;
            this.userProvider = userProvider;
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

            string responseJSON = "";
            if (response is CollectionResponse<IResponse>)
            {
                CollectionResponse<IResponse> collectionResponse = response as CollectionResponse<IResponse>;
                responseJSON = JsonConvert.SerializeObject(collectionResponse.Items().ToArray(), new JsonApiSerializerSettings());
                return Ok(JsonConvert.DeserializeObject(responseJSON, new JsonApiSerializerSettings()));
            }
            responseJSON = JsonConvert.SerializeObject(response, new JsonApiSerializerSettings());
            return Ok(JsonConvert.DeserializeObject(responseJSON, new JsonApiSerializerSettings()));
        }

        protected string GetUserId()
        {
            return this.userProvider.GetUser().userId;
        }
    }
}
