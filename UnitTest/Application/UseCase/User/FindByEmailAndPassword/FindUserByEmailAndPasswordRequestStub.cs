using BlockbusterApp.src.Application.UseCase.User.FindByEmalAndPassword;
using System;
using System.Collections.Generic;
using System.Text;
using UnitTest.Domain.UserAggregate.Stub;

namespace UnitTest.Application.UseCase.User.FindByEmailAndPassword
{

    public class FindUserByEmailAndPasswordRequestStub
    {
        public static FindUserByEmailAndPasswordRequest Create(
            string Email,
            string Password
            )
        {
            return new FindUserByEmailAndPasswordRequest(Email,Password);
        }

        public static FindUserByEmailAndPasswordRequest ByDefault()
        {
            return new FindUserByEmailAndPasswordRequest(
                UserEmailStub.ByDefault().GetValue(),
                UserPasswordStub.ByDefault().GetValue()
            );
        }
    }
}
