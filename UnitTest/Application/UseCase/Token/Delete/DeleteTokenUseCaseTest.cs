using BlockbusterApp.src.Application.UseCase.Token.Delete;
using BlockbusterApp.src.Domain.TokenAggregate;
using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using Moq;
using NUnit.Framework;
using UnitTest.Domain.Repository;
using UnitTest.Domain.TokenAggregate.Stub;

namespace UnitTest.Application.UseCase.Token.Delete
{
    [TestFixture]
    public class DeleteTokenUseCaseTest
    {
        [Test]
        public void ItShouldCallCollaborators()
        {
            DeleteTokenRequest request = DeleteTokenRequestStub.ByDefault();
            BlockbusterApp.src.Domain.TokenAggregate.Token token = TokenStub.ByDefault();
            Mock<ITokenRepository> tokenRepository = RepositoryStub.CreateTokenRepository();
            tokenRepository.Setup(o => o.FindByUserIdAndHash(It.IsAny<TokenUserId>(), It.IsAny<TokenHash>())).Returns(token);
            tokenRepository.Setup(o => o.Remove(token));
            Mock<EmptyResponseConverter> converter = new Mock<EmptyResponseConverter>();
            converter.Setup(o => o.Convert());
            DeleteTokenUseCase useCase = new DeleteTokenUseCase(tokenRepository.Object, converter.Object);           

            useCase.Execute(request);

            tokenRepository.VerifyAll();
            converter.VerifyAll();
        }
    }
}
