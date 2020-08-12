using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using BlockbusterApp.src.Shared.Infraestructure.Bus.UseCase.Response;
using System.Diagnostics.CodeAnalysis;

namespace BlockbusterApp.src.Shared.Infraestructure.Bus.Middleware
{
    [ExcludeFromCodeCoverage]
    public class ResponseMiddleware : MiddlewareHandler
    {
        private JSONFormatter jsonFormater;
        public ResponseMiddleware(JSONFormatter jsonFormater)
        {
            this.jsonFormater = jsonFormater;
        }

        public string Name()
        {
            return this.GetType().Name;
        }

        public override IResponse Handle(IRequest request)
        {
            IResponse response = base.Handle(request);
            return this.jsonFormater.Convert(response);            
        }
    }
}
