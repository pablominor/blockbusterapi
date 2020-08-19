using BlockbusterApp.src.Domain.TokenAggregate;
using BlockbusterApp.src.Shared.Application.Bus.UseCase;

namespace BlockbusterApp.src.Application.UseCase.Token.Delete
{
    public class DeleteTokenUseCase : IUseCase
    {

        private ITokenRepository tokenRepository;
        private EmptyResponseConverter converter;
        public DeleteTokenUseCase(
            ITokenRepository tokenRepository,
            EmptyResponseConverter converter)
        {
            this.tokenRepository = tokenRepository;
            this.converter = converter;
        }

        public IResponse Execute(IRequest req)
        {
            DeleteTokenRequest request = req as DeleteTokenRequest;

            TokenUserId userId = new TokenUserId(request.tokenUserId);
            TokenHash hash = new TokenHash(request.tokenHash);

            Domain.TokenAggregate.Token token = this.tokenRepository.FindByUserIdAndHash(userId, hash);

            this.tokenRepository.Remove(token);

            return this.converter.Convert();
        }
    }
}
