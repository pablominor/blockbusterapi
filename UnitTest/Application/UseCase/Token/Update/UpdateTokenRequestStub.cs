using BlockbusterApp.src.Application.UseCase.Token.Update;
using System;
using System.Collections.Generic;
using System.Text;
using UnitTest.Domain.TokenAggregate.Stub;

namespace UnitTest.Application.UseCase.Token.Update
{
    public class UpdateTokenRequestStub
    {
        public static UpdateTokenRequest Create(
            string tokeUserId,
            string tokenHash)
        {
            return new UpdateTokenRequest(tokeUserId, tokenHash);
        }

        public static UpdateTokenRequest ByDefault()
        {
            return new UpdateTokenRequest(
                TokenUserIdStub.ByDefault().GetValue(),
                TokenHashStub.ByDefault().GetValue()
            );
        }
    }
}
