using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;

namespace BlockbusterApp.src.Shared.Application.Bus.UseCase.Request
{
    public abstract class AbstractRequest : IRequest
    {
        private Dictionary<string, int> page;
        protected List<Filter> filters;

        public AbstractRequest(IQueryCollection query)
        {            
            this.SetPage(query["page[" + PaginationQueryParameters.PAGE_NUMBER + "]"], query["page[" + PaginationQueryParameters.PAGE_SIZE + "]"]);
            this.SetFilters(query);
        }

        public Dictionary<string, int> Page()
        {
            return this.page;
        }

        public List<Filter> Filter()
        {
            return this.filters;
        }

        private void SetPage(StringValues pageNumber, StringValues pageSize)
        {
            this.page = new Dictionary<string, int>();
            this.page = AddPageNumber(this.page, pageNumber);
            this.page = AddPageSize(this.page, pageSize);                     
        }

        private void SetFilters(IQueryCollection query)
        {
            this.filters = new List<Filter>();
            if (query.Keys == null) return;
            this.filters = AddFilters(this.filters, query);            
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

        private List<Filter> AddFilters(List<Filter> filters, IQueryCollection query)
        {
            foreach (var key in query.Keys)
            {
                if (key.Contains("filter"))
                {
                    string values = key.Replace("filter[", string.Empty);
                    values = values.Replace("]", string.Empty);
                    string[] filterValues = values.Split('.');
                    filters.Add(new Filter(filterValues[0], query[key].ToString().Split(',')));
                }
            }
            return filters;
        }
    }
}
