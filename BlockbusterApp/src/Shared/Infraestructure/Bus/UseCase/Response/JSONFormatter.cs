using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using BlockbusterApp.src.Shared.Application.Bus.UseCase.Response;
using BlockbusterApp.src.Shared.Infraestructure.Bus.Middleware.Exception;
using BlockbusterApp.src.Shared.Infraestructure.Bus.UseCase.URL;
using System.Collections.Generic;

namespace BlockbusterApp.src.Shared.Infraestructure.Bus.UseCase.Response
{
    public class JSONFormatter
    {

        private IUrlProvider urlProvider;

        public JSONFormatter(IUrlProvider urlProvider)
        {
            this.urlProvider = urlProvider;
        }


        public IResponse Convert(IResponse res)
        {
            if (res is ExceptionResponse) return res;
            JSONResponse<IResponse> JSONResponse = new JSONResponse<IResponse>();
            JSONResponse.data = new List<JSONDataResponse<IResponse>>();
            JSONResponse.links = new JSONLinksResponse();
            JSONResponse.links.self = this.urlProvider.GetUrlHelper().self;
            if (res is CollectionResponse<IResponse>)
            {
                CollectionResponse<IResponse> collectionResponse = res as CollectionResponse<IResponse>;
                foreach (var obj in collectionResponse.Items())
                {
                    JSONDataResponse<IResponse> JSONDataResponse = new JSONDataResponse<IResponse>();
                    JSONDataResponse.type = this.urlProvider.GetUrlHelper().type;
                    JSONDataResponse.attributes = obj;
                    JSONResponse.data.Add(JSONDataResponse);
                }
            }
            else
            {
                JSONDataResponse<IResponse> JSONDataResponse = new JSONDataResponse<IResponse>();
                JSONDataResponse.type = this.urlProvider.GetUrlHelper().type;
                JSONDataResponse.attributes = res;
                JSONResponse.data.Add(JSONDataResponse);
            }
            return JSONResponse;
        }


    }
}
