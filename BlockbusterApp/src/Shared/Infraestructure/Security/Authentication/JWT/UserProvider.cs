using BlockbusterApp.src.Shared.Infraestructure.Security.Authentication.JWT.Entity;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Security.Claims;

namespace BlockbusterApp.src.Shared.Infraestructure.Security.Authentication.JWT
{
    public class UserProvider : IUserProvider
    {
        private readonly IHttpContextAccessor _context;

        public UserProvider(IHttpContextAccessor context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public AuthUser GetUser()
        {
            return AuthUser.Create(
                _context.HttpContext.User.Claims.First(i => i.Type == TokenClaimTypes.USER_ID).Value,
                _context.HttpContext.User.FindFirst(ClaimTypes.Email).Value,
                _context.HttpContext.User.Claims.First(i => i.Type == TokenClaimTypes.FIRST_NAME).Value,
                _context.HttpContext.User.Claims.First(i => i.Type == TokenClaimTypes.LAST_NAME).Value,
                _context.HttpContext.User.FindFirst(ClaimTypes.Role).Value);
        }
    }

}
