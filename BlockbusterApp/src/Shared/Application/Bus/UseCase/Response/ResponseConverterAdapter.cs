using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Shared.Application.Bus.UseCase.Response
{
    public abstract class ResponseConverterAdapter
    {
        private ResponseConverter converter;

        public ResponseConverterAdapter(ResponseConverter converter)
        {
            this.converter = converter;
        }


        public CollectionResponse<IResponse> Convert(IEnumerable<dynamic> objects)
        {
            CollectionResponse<IResponse> collectionResponse = new CollectionResponse<IResponse>();

            foreach (var obj in objects)
            {
                IResponse responseUser = this.converter.Convert(obj);
                collectionResponse.Add(responseUser);
            }

            return collectionResponse;
        }
    }
}
