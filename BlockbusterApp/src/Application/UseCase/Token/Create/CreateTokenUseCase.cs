using BlockbusterApp.src.Application.UseCase.Token.Update;
using BlockbusterApp.src.Domain.TokenAggregate;
using BlockbusterApp.src.Infraestructure.Service.Token;
using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using BlockbusterApp.src.Shared.Infraestructure.Bus.UseCase;
using BlockbusterApp.src.Shared.Infraestructure.Security.Authentication.JWT;
using System.Collections.Generic;

namespace BlockbusterApp.src.Application.UseCase.Token.Create
{
    public class CreateTokenUseCase : IUseCase
    {

        private TokenAdapter tokenAdapter;
        private ITokenFactory tokenFactory;
        private ITokenRepository tokenRepository;
        private TokenConverter tokenConverter;
        private IUseCaseBus useCaseBus;

        public CreateTokenUseCase(
            TokenAdapter tokenAdapter,
            ITokenFactory tokenFactory,
            ITokenRepository tokenRepository,
            TokenConverter tokenConverter,
            IUseCaseBus useCaseBus
            )
        {
            this.tokenAdapter = tokenAdapter;
            this.tokenFactory = tokenFactory;
            this.tokenRepository = tokenRepository;
            this.tokenConverter = tokenConverter;
            this.useCaseBus = useCaseBus;
        }

        public IResponse Execute(IRequest req)
        {
            CreateTokenRequest request = req as CreateTokenRequest;

            Dictionary<string, string> payload = this.tokenAdapter.FindPayloadFromEmailAndPassword(request.Email,request.Password);
            TokenUserId tokenUserId = new TokenUserId(payload[TokenClaimTypes.USER_ID]);
            var token = this.tokenRepository.FindByUserId(tokenUserId);
            if(token != null)
            {
                return this.useCaseBus.Dispatch(new UpdateTokenRequest(tokenUserId.GetValue(), token.hash.GetValue()));
            }
            token = this.tokenFactory.Create(payload);
            this.tokenRepository.Add(token);
            return this.tokenConverter.Convert(token);
        }
    }
}
