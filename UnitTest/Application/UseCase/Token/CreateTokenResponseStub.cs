using BlockbusterApp.src.Application.UseCase.Token.Create;
using System;
using System.Collections.Generic;
using System.Text;
using UnitTest.Domain.TokenAggregate.Stub;

namespace UnitTest.Application.UseCase.Token
{
    public class CreateTokenResponseStub
    {
        public static CreateTokenResponse Create(
            string Hash)
        {
            return new CreateTokenResponse()
            {
                Hash = Hash
            };
        }

        public static CreateTokenResponse ByDefault()
        {
            return new CreateTokenResponse
            {
                Hash = TokenHashStub.ByDefault().GetValue()
            };
        }
    }
}
