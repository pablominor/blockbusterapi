using BlockbusterApp.src.Shared.Application.Bus.UseCase.Request;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace BlockbusterApp.src.Application.UseCase.Product.FindByFilter
{
    public class FindProductsByFilterRequest : AbstractRequest
    {
        public FindProductsByFilterRequest(IQueryCollection query) : base(query) { }
    }
}
