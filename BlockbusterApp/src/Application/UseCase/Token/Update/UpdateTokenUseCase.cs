using BlockbusterApp.src.Application.UseCase.Token.Response;
using BlockbusterApp.src.Domain.TokenAggregate;
using BlockbusterApp.src.Infraestructure.Service.Token;
using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using BlockbusterApp.src.Shared.Infraestructure.Security.Authentication.JWT;
using System.Collections.Generic;

namespace BlockbusterApp.src.Application.UseCase.Token.Update
{
    public class UpdateTokenUseCase : IUseCase
    {
        private ITokenRepository tokenRepository;
        private TokenConverter tokenConverter;
        private TokenAdapter tokenAdapter;
        private IJWTEncoder JWTEnconder;

        public UpdateTokenUseCase(
            ITokenRepository tokenRepository,
            TokenConverter tokenConverter,
            TokenAdapter tokenAdapter,
            IJWTEncoder JWTEnconder)
        {
            this.tokenRepository = tokenRepository;
            this.tokenConverter = tokenConverter;
            this.tokenAdapter = tokenAdapter;
            this.JWTEnconder = JWTEnconder;
        }

        public IResponse Execute(IRequest req)
        {
            UpdateTokenRequest request = req as UpdateTokenRequest;
            TokenUserId userId = new TokenUserId(request.tokenUserId);
            TokenHash hash = new TokenHash(request.tokenHash);

            Domain.TokenAggregate.Token token = this.tokenRepository.FindByUserIdAndHash(userId,hash);

            Dictionary<string, string> payload = this.tokenAdapter.FindPayloadFromUserId(token.userId.GetValue());

            TokenHash tokenHash = new TokenHash(this.JWTEnconder.Encode(payload));

            token.UpdateHash(tokenHash);            

            this.tokenRepository.Update(token);

            return this.tokenConverter.Convert(token);
        }
    }
}
