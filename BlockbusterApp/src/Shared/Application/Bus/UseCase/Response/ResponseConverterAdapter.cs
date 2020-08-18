using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Shared.Application.Bus.UseCase.Response
{
    public class ResponseConverterAdapter
    {
        private ResponseConverter converter;

        public ResponseConverterAdapter(ResponseConverter converter)
        {
            this.converter = converter;
        }


        public virtual CollectionResponse<IResponse> Convert(IEnumerable<dynamic> objects)
        {
            CollectionResponse<IResponse> collectionResponse = new CollectionResponse<IResponse>();

            collectionResponse.Clear();

            foreach (var obj in objects)
            {
                IResponse responseUser = this.converter.Convert(obj);
                collectionResponse.Add(responseUser);
            }

            return collectionResponse;
        }
    }
}
