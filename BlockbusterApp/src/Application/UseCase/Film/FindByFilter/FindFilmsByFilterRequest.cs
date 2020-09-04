using BlockbusterApp.src.Shared.Application.Bus.UseCase.Request;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace BlockbusterApp.src.Application.UseCase.Film.FindByFilter
{
    public class FindFilmsByFilterRequest : AbstractRequest
    {

        private const string FILTER_NAME = "name";

        public FindFilmsByFilterRequest(IQueryCollection query) : base(query) { }

        public string[] Names()
        {
            return this.Filter().Where(f => f.property.Equals(FILTER_NAME)).FirstOrDefault().values;
        }
    }
}
