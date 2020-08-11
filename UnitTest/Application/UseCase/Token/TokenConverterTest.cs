using BlockbusterApp.src.Application.UseCase.Token;
using BlockbusterApp.src.Domain.TokenAggregate;
using NUnit.Framework;
using UnitTest.Domain.TokenAggregate.Stub;

namespace UnitTest.Application.UseCase.Token
{
    [TestFixture]
    public class TokenConverterTest
    {

        [Test]
        public void ItShouldReturnCorrectResponse()
        {
            BlockbusterApp.src.Domain.TokenAggregate.Token token = TokenStub.ByDefault();
            TokenConverter converter = new TokenConverter();

            var res = converter.Convert(token);

            Assert.IsInstanceOf<CreateTokenResponse>(res);
            CreateTokenResponse response = res as CreateTokenResponse;
            Assert.AreEqual(response.Hash, token.hash.GetValue());            
        }
    }
}
