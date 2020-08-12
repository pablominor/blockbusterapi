using BlockbusterApp.src.Shared.Infraestructure.Bus.UseCase.URL.Entity;
using Microsoft.AspNetCore.Http;
using System;

namespace BlockbusterApp.src.Shared.Infraestructure.Bus.UseCase.URL
{
    public class UrlProvider : IUrlProvider
    {
        private readonly IHttpContextAccessor _context;

        public UrlProvider(IHttpContextAccessor context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public UrlHelper GetUrlHelper()
        {
            return UrlHelper.Create(
                _context.HttpContext.Request.Path,
                this.ExtractTypeFromUrl(_context.HttpContext.Request.Path.ToString())
                );
        }

        private string ExtractTypeFromUrl(string path)
        {
            return path.Split('/')[3];
        }


    }
}
