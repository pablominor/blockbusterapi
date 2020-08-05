﻿using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using BlockbusterApp.src.Shared.Domain.Exception;
using BlockbusterApp.src.Shared.Infraestructure.Bus.Middleware.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Shared.Infraestructure.Bus.Middleware
{
    public class ExceptionMiddleware : MiddlewareHandler
    {
        private ExceptionConverter converter;
        public ExceptionMiddleware(ExceptionConverter converter)
        {
            this.converter = converter;
        }

        public override IResponse Handle(IRequest request)
        {
            try
            {
                IResponse response = base.Handle(request);
                return response;
            }
            catch (ValidationException validation)
            {
                return this.converter.Convert("400", validation.Message);
            }
            catch(SecurityException validation)
            {
                return this.converter.Convert("403", validation.Message);
            }
            catch(System.Exception ex)
            {
                return this.converter.Convert("500", ex.Message);
            }
        }
    }
}
