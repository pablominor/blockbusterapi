using BlockbusterApp.src.Application.UseCase.Token;
using BlockbusterApp.src.Domain.TokenAggregate;
using BlockbusterApp.src.Domain.UserAggregate;
using BlockbusterApp.src.Infraestructure.Service.Token;
using BlockbusterApp.src.Shared.Infraestructure.Bus.UseCase;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using UnitTest.Stub.Request;
using UnitTest.Stub.UserAggregate;

namespace UnitTest.Application.UseCase.Token
{
    [TestFixture]
    public class CreateTokenUseCaseTest
    {

        [Test]
        public void ItShouldCallCollaborators()
        {
            CreateTokenRequest request = CreateTokenRequestStub.ByDefault();
            Dictionary<string, string> payload = PayloadStub.ByDefault();
            Mock<TokenAdapter> tokenAdapter = getTokenAdapter();
            tokenAdapter.Setup(o => o.FindPayloadFromEmailAndPassword(request.Email, request.Password)).Returns(payload);
            BlockbusterApp.src.Domain.TokenAggregate.Token token = TokenStub.ByDefault();
            Mock<ITokenFactory> tokenFactory = new Mock<ITokenFactory>();
            tokenFactory.Setup(o => o.Create(payload)).Returns(token);
            Mock<ITokenRepository> tokenRepository = new Mock<ITokenRepository>();
            tokenRepository.Setup(o => o.Add(token));
            Mock<TokenConverter> tokenConverter = new Mock<TokenConverter>();
            tokenConverter.Setup(o => o.Convert(token));
            CreateTokenUseCase useCase = new CreateTokenUseCase(
                tokenAdapter.Object,
                tokenFactory.Object,
                tokenRepository.Object,
                tokenConverter.Object);

            useCase.Execute(request);

            tokenAdapter.VerifyAll();
            tokenFactory.VerifyAll();
            tokenRepository.VerifyAll();
            tokenConverter.VerifyAll();
        }


        private Mock<TokenAdapter> getTokenAdapter()
        {
            Mock<TokenFacade> tokenFacade = getTokenFacade();
            Mock<TokenTranslator> tokenTranslator = new Mock<TokenTranslator>();
            Mock<TokenAdapter> tokenAdapter = new Mock<TokenAdapter>(tokenFacade.Object, tokenTranslator.Object);
            return tokenAdapter;
        }

        private Mock<TokenFacade> getTokenFacade()
        {
            Mock<IUseCaseBus> useCaseBus = new Mock<IUseCaseBus>();
            Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
            Mock<TokenFacade> tokenFacade = new Mock<TokenFacade>(useCaseBus.Object,userRepository.Object);
            return tokenFacade;
        }
    }
}
