using BlockbusterApp.src.Shared.Domain.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Infraestructure.Security.User.Exception
{
    public class UserAuthorizationException : SecurityException
    {
        public UserAuthorizationException(string message) : base(message) { }

    }
}
