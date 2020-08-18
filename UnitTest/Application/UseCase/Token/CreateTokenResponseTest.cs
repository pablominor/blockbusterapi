using BlockbusterApp.src.Application.UseCase.Token.Response;
using NUnit.Framework;
using UnitTest.Domain.TokenAggregate.Stub;

namespace UnitTest.Application.UseCase.Token
{
    [TestFixture]
    public class CreateTokenResponseTest
    {
        [Test]
        public void ItShouldReturnCorrectResponse()
        {
            BlockbusterApp.src.Domain.TokenAggregate.Token token = TokenStub.ByDefault();

            CreateTokenResponse response = new CreateTokenResponse
            {
                Hash = token.hash.GetValue()
            };

            Assert.AreEqual(response.Hash, token.hash.GetValue());
        }
    }
}
