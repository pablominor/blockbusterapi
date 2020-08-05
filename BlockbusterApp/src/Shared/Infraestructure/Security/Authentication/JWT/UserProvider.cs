using BlockbusterApp.src.Domain.TokenAggregate;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Shared.Infraestructure.Security.Authentication.JWT
{
    public class UserProvider : IUserProvider
    {
        private readonly IHttpContextAccessor _context;

        public UserProvider(IHttpContextAccessor context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public string GetUserId()
        {
            return _context.HttpContext.User.Claims
                       .First(i => i.Type == TokenClaimTypes.USER_ID).Value;
        }
    }

}
