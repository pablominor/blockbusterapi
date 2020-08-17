using BlockbusterApp.src.Application.UseCase.Token;
using BlockbusterApp.src.Domain.TokenAggregate;
using BlockbusterApp.src.Domain.UserAggregate;
using BlockbusterApp.src.Infraestructure.Service.Token;
using BlockbusterApp.src.Shared.Infraestructure.Bus.UseCase;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using UnitTest.Stub.Request;
using UnitTest.Domain.TokenAggregate.Stub;
using UnitTest.Domain.UserAggregate.Stub;
using UnitTest.Domain.Repository;
using BlockbusterApp.src.Application.UseCase.Token.Create;
using UnitTest.Shared.Application.Bus.UseCase;
using System.Threading.Tasks;
using BlockbusterApp.src.Domain.UserAggregate.Service;
using UnitTest.Application.UseCase.User.FindById;
using BlockbusterApp.src.Shared.Application.Bus.UseCase;

namespace UnitTest.Application.UseCase.Token.Create
{
    [TestFixture]
    public class CreateTokenUseCaseTest
    {

        [Test]
        public void ItShouldCallCollaboratorsWhenCreateToken()
        {
            CreateTokenRequest request = CreateTokenRequestStub.ByDefault();
            Mock<TokenAdapter> tokenAdapter = getTokenAdapterWithSetupConfigured(request);
            BlockbusterApp.src.Domain.TokenAggregate.Token token = TokenStub.ByDefault();
            Mock<ITokenFactory> tokenFactory = new Mock<ITokenFactory>();
            tokenFactory.Setup(o => o.Create(It.IsAny<Dictionary<string,string>>())).Returns(token);
            Mock<ITokenRepository> tokenRepository = RepositoryStub.CreateTokenRepository();
            tokenRepository.Setup(o => o.FindByUserId(It.IsAny<TokenUserId>())).Returns(TokenStub.NullToken());
            tokenRepository.Setup(o => o.Add(token));
            Mock<TokenConverter> tokenConverter = new Mock<TokenConverter>();
            tokenConverter.Setup(o => o.Convert(token));
            Mock<IUseCaseBus> useCaseBus = UseCaseBusMockGenerator.CreateUseCaseBusThatDispatchAnyRequest();
            CreateTokenUseCase useCase = new CreateTokenUseCase(
                tokenAdapter.Object,
                tokenFactory.Object,
                tokenRepository.Object,
                tokenConverter.Object,
                useCaseBus.Object);

            useCase.Execute(request);

            tokenAdapter.VerifyAll();
            tokenFactory.VerifyAll();
            tokenRepository.VerifyAll();
            tokenConverter.VerifyAll();
        }

        [Test]
        public void ItShouldCallCollaboratorsWhenUpdateToken()
        {
            CreateTokenRequest request = CreateTokenRequestStub.ByDefault();
            Mock<TokenAdapter> tokenAdapter = getTokenAdapterWithSetupConfigured(request);            
            BlockbusterApp.src.Domain.TokenAggregate.Token token = TokenStub.ByDefault();
            Mock<ITokenFactory> tokenFactory = new Mock<ITokenFactory>();
            Mock<ITokenRepository> tokenRepository = RepositoryStub.CreateTokenRepository();
            tokenRepository.Setup(o => o.FindByUserId(It.IsAny<TokenUserId>())).Returns(TokenStub.ByDefault());
            Mock<TokenConverter> tokenConverter = new Mock<TokenConverter>();
            Mock<IUseCaseBus> useCaseBus = getUseCaseBus();
            CreateTokenUseCase useCase = new CreateTokenUseCase(
                tokenAdapter.Object,
                tokenFactory.Object,
                tokenRepository.Object,
                tokenConverter.Object,
                useCaseBus.Object);

            useCase.Execute(request);

            tokenAdapter.VerifyAll();
            tokenRepository.VerifyAll();
            useCaseBus.VerifyAll();
        }


        private Mock<TokenAdapter> getTokenAdapterWithSetupConfigured(CreateTokenRequest request)
        {
            Mock<TokenAdapter> tokenAdapter = TokenAdapterStub.ByDefault();
            Dictionary<string, string> payload = PayloadStub.ByDefault();
            tokenAdapter.Setup(o => o.FindPayloadFromEmailAndPassword(request.Email, request.Password)).Returns(payload);
            return tokenAdapter;
        }

        private Mock<IUseCaseBus> getUseCaseBus()
        {
            Mock<IUseCaseBus> useCaseBus = new Mock<IUseCaseBus>();
            CreateTokenResponse response = CreateTokenResponseStub.ByDefault();
            useCaseBus.Setup(o => o.Dispatch(It.IsAny<IRequest>())).Returns(response);
            return useCaseBus;
        }

    }
}
