using BlockbusterApp.src.Application.UseCase.Token.Create;
using BlockbusterApp.src.Domain.TokenAggregate;
using BlockbusterApp.src.Domain.TokenAggregate.Service;
using BlockbusterApp.src.Shared.Application.Bus.UseCase;

namespace BlockbusterApp.src.Application.UseCase.Token.Update
{
    public class UpdateTokenUseCase : IUseCase
    {

        private TokenUpdaterService tokenUpdaterService;
        private ITokenRepository tokenRepository;
        private TokenConverter tokenConverter;

        public UpdateTokenUseCase(
            TokenUpdaterService tokenUpdaterService, 
            ITokenRepository tokenRepository,
            TokenConverter tokenConverter)
        {
            this.tokenUpdaterService = tokenUpdaterService;
            this.tokenRepository = tokenRepository;
            this.tokenConverter = tokenConverter;
        }

        public IResponse Execute(IRequest req)
        {
            UpdateTokenRequest request = req as UpdateTokenRequest;

            Domain.TokenAggregate.Token token = this.tokenUpdaterService.UpdateTokenHash(request.Token, request.Payload);
            
            this.tokenRepository.Update(token);

            return this.tokenConverter.Convert(token);
        }
    }
}
