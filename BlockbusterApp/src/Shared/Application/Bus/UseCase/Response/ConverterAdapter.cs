using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Shared.Application.Bus.UseCase.Response
{
    public abstract class ConverterAdapter
    {
        private Converter converter;

        public ConverterAdapter(Converter converter)
        {
            this.converter = converter;
        }

        public abstract IResponse Convert(IEnumerable<dynamic> objects);

        public List<IResponse> GetListResponses(IEnumerable<dynamic> objects)
        {
            List<IResponse> data = new List<IResponse>();

            foreach (var obj in objects)
            {
                IResponse responseUser = this.converter.Convert(obj);
                data.Add(responseUser);
            }

            return data;
        }
    }
}
