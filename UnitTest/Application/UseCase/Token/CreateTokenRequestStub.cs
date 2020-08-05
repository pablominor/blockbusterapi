using BlockbusterApp.src.Application.UseCase.Token;
using BlockbusterApp.src.Application.UseCase.User.SignUP;
using System;
using System.Collections.Generic;
using System.Text;
using UnitTest.Stub.UserAggregate;

namespace UnitTest.Stub.Request
{
    public class CreateTokenRequestStub
    {

        public static CreateTokenRequest Create(
            string Email,
            string Password)
        {
            return new CreateTokenRequest(Email,Password);
        }

        public static CreateTokenRequest ByDefault()
        {
            return new CreateTokenRequest(
                UserEmailStub.ByDefault().GetValue(),
                UserPasswordStub.ByDefault().GetValue()
            );
        }

    }
}
