using BlockbusterApp.src.Application.UseCase.Token;
using BlockbusterApp.src.Application.UseCase.User.SignUP;
using BlockbusterApp.src.Domain.TokenAggregate;
using BlockbusterApp.src.Domain.UserAggregate;
using BlockbusterApp.src.Shared.Infraestructure.Security.Authentication.JWT;
using Microsoft.AspNetCore.Http;
using NUnit.Framework.Constraints;
using System;
using System.Collections.Generic;
using System.Net.Cache;
using System.Runtime.CompilerServices;
using System.Text;
using UnitTest.Domain.TokenAggregate.Stub;

namespace UnitTest.Stub.UserAggregate
{
    public class PayloadStub
    {

        public static Dictionary<string, string> ByDefault()
        {
            return new Dictionary<string, string>()
            {
                [TokenClaimTypes.USER_ID] = UserIdStub.ByDefault().GetValue(),
                [TokenClaimTypes.EMAIL] = UserEmailStub.ByDefault().GetValue(),
                [TokenClaimTypes.FIRST_NAME] = UserFirstNameStub.ByDefault().GetValue(),
                [TokenClaimTypes.LAST_NAME] = UserLastNameStub.ByDefault().GetValue(),
                [TokenClaimTypes.ROLE] = UserRoleStub.CreateLikeAdmin().GetValue()
            };
        }
       
    }
}
