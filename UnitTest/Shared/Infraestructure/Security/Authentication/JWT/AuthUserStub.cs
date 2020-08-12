using BlockbusterApp.src.Shared.Infraestructure.Security.Authentication.JWT.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using UnitTest.Domain.UserAggregate.Stub;

namespace UnitTest.Shared.Infraestructure.Security.Authentication.JWT
{
    public class AuthUserStub
    {

        public static AuthUser ByDefaultWithRoleUser()
        {
            return Create(
                UserIdStub.ByDefault().GetValue(),
                UserEmailStub.ByDefault().GetValue(),
                UserFirstNameStub.ByDefault().GetValue(),
                UserLastNameStub.ByDefault().GetValue(),
                UserRoleStub.CreateLikeUser().GetValue()
            );
        }

        public static AuthUser ByDefaultWithRoleAdmin()
        {
            return Create(
                UserIdStub.ByDefault().GetValue(),
                UserEmailStub.ByDefault().GetValue(),
                UserFirstNameStub.ByDefault().GetValue(),
                UserLastNameStub.ByDefault().GetValue(),
                UserRoleStub.CreateLikeAdmin().GetValue()
            );
        }

        private static AuthUser Create(
            string userId,
            string email,
            string firstName,
            string lastName,
            string role)
        {
            return AuthUser.Create(
                userId,
                email,
                firstName,
                lastName,
                role);
        }


    }
}
