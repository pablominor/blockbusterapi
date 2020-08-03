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

        public IResponse Convert(IEnumerable<dynamic> objects)
        {
            ResponseList responseList = new ResponseList();

            foreach (var obj in objects)
            {
                IResponse responseUser = this.converter.Convert(obj);
                responseList.AllResponses.Add(responseUser);
            }

            return responseList;
        }
    }
}
