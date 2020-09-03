using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Shared.Application.Bus.UseCase.Request
{
    public class Filter
    {
        public string property { get; }
        public string[] values { get; }

        public Filter(string property,string[] values)
        {
            this.property = property;
            this.values = values;
        }
    }
}
