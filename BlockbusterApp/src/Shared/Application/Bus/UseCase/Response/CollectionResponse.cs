using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Shared.Application.Bus.UseCase.Response
{
    public class CollectionResponse<T> : IResponse
    {
        protected List<T> items;

        public CollectionResponse()
        {
            this.items = new List<T>();
        }

        public void Add(T values)
        {
            this.items.Add(values);
        }

        public void Clear()
        {
            this.items = new List<T>();
        }

        public List<T> Items()
        {
            return this.items;
        }
    }
}
