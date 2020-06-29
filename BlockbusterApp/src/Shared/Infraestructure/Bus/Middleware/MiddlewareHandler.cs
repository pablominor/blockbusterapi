using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Shared.Infraestructure.Bus.Middleware
{
    public abstract class MiddlewareHandler : IMiddlewareHandler
    {
        private IMiddlewareHandler nextHandler;

        public IMiddlewareHandler SetNext(IMiddlewareHandler handler)
        {
            nextHandler = handler;
            return handler;
        }

        public virtual IResponse Handle(IRequest request)
        {
            return nextHandler.Handle(request);
        }
    }
}
