using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Shared.Application.Bus.UseCase.Response
{
    public abstract class ResponseConverter
    {
        public abstract IResponse Convert(dynamic item);

    }
}
