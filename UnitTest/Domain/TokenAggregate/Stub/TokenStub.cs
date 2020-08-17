using BlockbusterApp.src.Domain.TokenAggregate;

namespace UnitTest.Domain.TokenAggregate.Stub
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

        public static Token NullToken()
        {
            return null;
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
