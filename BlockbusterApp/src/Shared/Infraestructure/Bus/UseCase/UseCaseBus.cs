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
                if (IsTransactionMiddleware(middlewareHandler) && !UseCaseCalledFromController(stackClassName)) { continue; } 
                if (IsExceptionMiddleware(middlewareHandler) && !UseCaseCalledFromController(stackClassName)) { continue; }
                middlewareHandler.SetNext(mHandler);
                mHandler = middlewareHandler;
            }

            return mHandler.Handle(req);
        }

        private bool IsTransactionMiddleware(IMiddlewareHandler middlewareHandler)
        {
            return middlewareHandler.GetType().Name == typeof(TransactionMiddleware).Name;
        }

        private bool IsExceptionMiddleware(IMiddlewareHandler middlewareHandler)
        {
            return middlewareHandler.GetType().Name == typeof(ExceptionMiddleware).Name;
        }

        private bool UseCaseCalledFromController(string stackClassName)
        {            
            return stackClassName == typeof(Controller).Name;
        }
    }
}
