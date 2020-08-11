using BlockbusterApp.src.Domain.UserAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace  UnitTest.Domain.UserAggregate.Stub
{
    public class UserRoleStub
    {

        public static UserRole Create(string role)
        {
            return new UserRole(role);
        }

        public static UserRole CreateLikeAdmin()
        {
            return new UserRole(UserRole.ROLE_ADMIN);
        }

        public static UserRole CreateLikeUser()
        {
            return new UserRole(UserRole.ROLE_USER);
        }
    }
}
