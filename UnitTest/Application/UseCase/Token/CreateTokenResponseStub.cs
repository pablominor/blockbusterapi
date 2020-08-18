using BlockbusterApp.src.Application.UseCase.Token.Response;
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
