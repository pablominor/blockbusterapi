using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;

namespace BlockbusterApp.src.Shared.Application.Bus.UseCase.Request
{
    public abstract class AbstractRequest : IRequest
    {
        private Dictionary<string, int> page;
        protected Dictionary<string, string> filter;

        public AbstractRequest(IQueryCollection query)
        {            
            this.SetPage(query["page[" + PaginationQueryParameters.PAGE_NUMBER + "]"], query["page[" + PaginationQueryParameters.PAGE_SIZE + "]"]);
            this.SetFilter(query);
        }

        public Dictionary<string, int> Page()
        {
            return this.page;
        }

        public Dictionary<string, string> Filter()
        {
            return this.filter;
        }

        private void SetPage(StringValues pageNumber, StringValues pageSize)
        {
            this.page = new Dictionary<string, int>();
            this.page = AddPageNumber(this.page, pageNumber);
            this.page = AddPageSize(this.page, pageSize);                     
        }

        private void SetFilter(IQueryCollection query)
        {
            this.filter = new Dictionary<string, string>();
            if (query.Keys == null) return;
            this.filter = AddFilters(this.filter, query);            
        }

        private Dictionary<string, int> AddPageNumber(Dictionary<string, int> page, StringValues pageNumber)
        {
            page.Add(
                PaginationQueryParameters.PAGE_NUMBER,
                pageNumber.Count > 0 ? System.Int16.Parse(pageNumber.ToString()) : PaginationQueryParameters.DEFAULT_NUMBER_OF_PAGES);
            return page;
        }

        private Dictionary<string, int> AddPageSize(Dictionary<string, int> page, StringValues pageSize)
        {
            page.Add(
                PaginationQueryParameters.PAGE_SIZE,
                pageSize.Count > 0 ? System.Int16.Parse(pageSize.ToString()) : PaginationQueryParameters.DEFAULT_SIZE);
            return page;
        }

        private Dictionary<string,string> AddFilters(Dictionary<string, string> filter, IQueryCollection query)
        {
            foreach (var key in query.Keys)
            {
                string[] keySplited = key.Split(new Char[] { '[', ']' });
                if (keySplited[0].Equals("filter"))
                {
                    filter.Add(keySplited[1], query[key]);
                }
            }
            return filter;
        }
    }
}
