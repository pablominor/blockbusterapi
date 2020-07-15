using BlockbusterApp.src.Domain.UserAggregate;
using BlockbusterApp.src.Shared.Domain.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Application.UseCase.Exception.User
{
    public class UserNotFoundException : ValidationException
    {
        public UserNotFoundException(string value) : base(value) { }

        public static UserNotFoundException FromId(UserId userId)
        {
            return new UserNotFoundException(String.Format("User not found with the id {0}.", userId.GetValue()));
        }
    }
}
