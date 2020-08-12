using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Shared.Infraestructure.Bus.UseCase.Response
{

    public class JSONResponse<T> : IResponse
    {
        public JSONLinksResponse links { get; set; }
        public List<JSONDataResponse<T>> data { get; set; }
    }

    public class JSONLinksResponse
    {
        public string self { get; set; }
    }

    public class JSONDataResponse<T>
    {
        public string type { get; set; }
        public T attributes { get; set; }
    }
}
