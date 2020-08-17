using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using System.Diagnostics.CodeAnalysis;

namespace BlockbusterApp.src.Shared.Infraestructure.Bus.Middleware
{
    
    public class UseCaseMiddleware : MiddlewareHandler
    {
        private IUseCase useCase;

        public UseCaseMiddleware(IUseCase useCase)
        {
            this.useCase = useCase;
        }

        public override IResponse Handle(IRequest request)
        {
            return useCase.Execute(request);
        }
    }
}
