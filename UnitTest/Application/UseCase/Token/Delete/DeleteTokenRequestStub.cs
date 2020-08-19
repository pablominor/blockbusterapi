using BlockbusterApp.src.Application.UseCase.Token.Delete;
using UnitTest.Domain.TokenAggregate.Stub;

namespace UnitTest.Application.UseCase.Token.Delete
{
    public class DeleteTokenRequestStub
    {

        public static DeleteTokenRequest Create(
            string TokenHash,
            string TokenUserId)
        {
            DeleteTokenRequest request = new DeleteTokenRequest(TokenHash);
            request.tokenUserId = TokenUserId;
            return request;
        }

        public static DeleteTokenRequest ByDefault()
        {
            DeleteTokenRequest request = new DeleteTokenRequest(TokenHashStub.ByDefault().GetValue());
            request.tokenUserId = TokenUserIdStub.ByDefault().GetValue();
            return request;
        }

    }
}
