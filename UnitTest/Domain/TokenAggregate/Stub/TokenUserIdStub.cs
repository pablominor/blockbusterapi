using BlockbusterApp.src.Domain.TokenAggregate;
using UnitTest.Domain.UserAggregate.Stub;

namespace UnitTest.Domain.TokenAggregate.Stub
{
    public class TokenUserIdStub
    {

        public static TokenUserId Crate(string hash)
        {
            return new TokenUserId(hash);
        }

        public static TokenUserId ByDefault()
        {
            return new TokenUserId(UserIdStub.ByDefault().GetValue());
        }
    }
}
