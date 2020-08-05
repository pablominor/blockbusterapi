using BlockbusterApp.src.Application.UseCase.Token;
using BlockbusterApp.src.Application.UseCase.User.SignUP;
using BlockbusterApp.src.Domain.TokenAggregate;
using BlockbusterApp.src.Domain.UserAggregate;
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
    public class TokenStub
    {

        public static Token ByDefault()
        {
            return Create(
                TokenHashStub.ByDefault(),
                TokenUserIdStub.ByDefault()
            );
        }
       

        private static Token Create(
            TokenHash Hash,
            TokenUserId UserId)
        {
            return Token.Create(
                Hash,
                UserId);
        }
    }
}
