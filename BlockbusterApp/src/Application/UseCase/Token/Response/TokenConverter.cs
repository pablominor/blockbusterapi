using BlockbusterApp.src.Shared.Application.Bus.UseCase;

namespace BlockbusterApp.src.Application.UseCase.Token.Response
{
    public class TokenConverter
    {
        public TokenConverter() { }

        public virtual IResponse Convert(Domain.TokenAggregate.Token token)
        {
            return new CreateTokenResponse()
            {
                Hash = token.hash.GetValue()
            };

        }
    }
}
