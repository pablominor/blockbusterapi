using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Shared.Application.Bus.UseCase
{
    public class EmptyResponseConverter
    {
        public EmptyResponseConverter() { }

        public virtual IResponse Convert()
        {
            return new EmptyResponse();
        }
    }
}
