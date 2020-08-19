using BlockbusterApp.src.Shared.Application.Bus.UseCase;

namespace BlockbusterApp.src.Application.UseCase.Token.Delete
{
    public class DeleteTokenRequest : IRequest
    {
        public DeleteTokenRequest(string TokenHash)
        {
            this.tokenHash = TokenHash;
        }

        public string tokenUserId { get; set; }
        public string tokenHash { get; set; }
    }
}
