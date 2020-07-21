using BlockbusterApp.src.Application.UseCase.User.SignUP;
using System;
using System.Collections.Generic;
using System.Text;
using UnitTest.Stub.UserAggregate;

namespace UnitTest.Stub.Request
{
    public class SignUpUserRequestStub
    {

        public static SignUpUserRequest Create(
            string Id,
            string Email,
            string Password,
            string RepeatPassword,
            string FirstName,
            string LastName,
            string Role,
            string CountryCode)
        {
            return new SignUpUserRequest(Id,Email,Password,RepeatPassword,FirstName,LastName,Role,CountryCode);
        }

        public static SignUpUserRequest ByDefault()
        {
            return new SignUpUserRequest(
                UserIdStub.ByDefault().GetValue(),
                UserEmailStub.ByDefault().GetValue(),
                UserPasswordStub.ByDefault().GetValue(),
                UserPasswordStub.ByDefault().GetValue(),
                UserFirstNameStub.ByDefault().GetValue(),
                UserLastNameStub.ByDefault().GetValue(),
                UserRoleStub.CreateLikeUser().GetValue(),
                UserCountryCodeStub.ByDefault().GetValue()
            );
        }

    }
}
