using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using BlockbusterApp.src.Shared.Infraestructure.Bus.Middleware;
using BlockbusterApp.src.Shared.UI.Rest.Controller;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Shared.Infraestructure.Bus.UseCase
{
    public class UseCaseBus : IUseCaseBus
    {
        private Dictionary<string, UseCaseMiddleware> useCases;
        private List<IMiddlewareHandler> middlewareHanders;

        private const string TRANSACTION_MIDDLEWARE = "TransactionMiddleware";
        private const string EXCEPTION_MIDDLEWARE = "ExceptionMiddleware";
        private const string RESPONSE_MIDDLEWARE = "ResponseMiddleware";

        public UseCaseBus()
        {
            useCases = new Dictionary<string, UseCaseMiddleware>();
        }

        public void SetMiddlewares(List<IMiddlewareHandler> middlewareHanders)
        {
            this.middlewareHanders = middlewareHanders;
        }

        public void Subscribe(IUseCase useCase)
        {
            string className = useCase.GetType().ToString();
            useCases.Add(className, new UseCaseMiddleware(useCase));
        }

        public IResponse Dispatch(IRequest req)
        {
            string className = req.GetType().ToString();
            string[] words = className.Split(new string[] { "Request" }, StringSplitOptions.None);

            string useCaseName = words[0] + "UseCase";

            if (!useCases.ContainsKey(useCaseName))
            {
                throw new Exception("Not exists the usecase " + useCaseName);
            }

            IMiddlewareHandler mHandler = this.useCases[useCaseName];

            StackFrame frame = new StackFrame(1, true);
            var stackClassName = frame.GetMethod().DeclaringType.Name;

            foreach (IMiddlewareHandler middlewareHandler in this.middlewareHanders)
            {
                if (ItShouldSkipMiddleware(middlewareHandler,stackClassName)) { continue; }
                middlewareHandler.SetNext(mHandler);
                mHandler = middlewareHandler;
            }

            return mHandler.Handle(req);
        }

        private bool ItShouldSkipMiddleware(IMiddlewareHandler middlewareHandler, string stackClassName)
        {
            return IsAMiddlewareThatCanOnlyBeCalledOnce(middlewareHandler)
                    && !CalledFromController(stackClassName);
        }

        private bool IsAMiddlewareThatCanOnlyBeCalledOnce(IMiddlewareHandler middlewareHandler)
        {
            string middlewareHandlerName = middlewareHandler.GetType().Name;
            switch (middlewareHandlerName)
            {
                case TRANSACTION_MIDDLEWARE:
                    return true;                  
                case EXCEPTION_MIDDLEWARE:
                    return true;
                case RESPONSE_MIDDLEWARE:
                    return true;
                default:
                    return false;
            }        
        }

        private bool CalledFromController(string stackClassName)
        {            
            return stackClassName == typeof(Controller).Name;
        }
    }
}
