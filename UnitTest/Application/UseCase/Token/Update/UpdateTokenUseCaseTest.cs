using BlockbusterApp.src.Application.UseCase.Token.Response;
using BlockbusterApp.src.Application.UseCase.Token.Update;
using BlockbusterApp.src.Domain.TokenAggregate;
using BlockbusterApp.src.Infraestructure.Service.Token;
using BlockbusterApp.src.Shared.Infraestructure.Security.Authentication.JWT;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using UnitTest.Domain.Repository;
using UnitTest.Domain.TokenAggregate.Stub;

namespace UnitTest.Application.UseCase.Token.Update
{
    [TestFixture]
    public class UpdateTokenUseCaseTest
    {

        [Test]
        public void ItShouldCallCollaborators()
        {
            UpdateTokenRequest request = UpdateTokenRequestStub.ByDefault();
            BlockbusterApp.src.Domain.TokenAggregate.Token token = TokenStub.ByDefault();
            Mock<ITokenRepository> tokenRepository = RepositoryStub.CreateTokenRepository();            
            tokenRepository.Setup(o => o.FindByUserIdAndHash(It.IsAny<TokenUserId>(),It.IsAny<TokenHash>())).Returns(token);
            Dictionary<string, string> payload = PayloadStub.ByDefault();
            Mock<TokenAdapter> tokenAdapter = TokenAdapterStub.ByDefault();
            tokenAdapter.Setup(o => o.FindPayloadFromUserId(It.IsAny<string>())).Returns(payload);            
            Mock<IJWTEncoder> JWTEnconder = new Mock<IJWTEncoder>();
            JWTEnconder.Setup(o => o.Encode(payload)).Returns(TokenHashStub.ByDefault().GetValue());
            tokenRepository.Setup(o => o.Update(token));
            Mock<TokenConverter> tokenConverter = new Mock<TokenConverter>();
            tokenConverter.Setup(o => o.Convert(token));
            UpdateTokenUseCase useCase = new UpdateTokenUseCase(
                tokenRepository.Object,
                tokenConverter.Object,
                tokenAdapter.Object,
                JWTEnconder.Object);

            useCase.Execute(request);

            tokenRepository.VerifyAll();
            tokenAdapter.VerifyAll();
            tokenConverter.VerifyAll();
            JWTEnconder.VerifyAll();
        }
    }
}
