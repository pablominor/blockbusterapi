namespace BlockbusterApp.src.Domain.TokenAggregate
{
    public interface ITokenRepository
    {
        void Add(Token token);
        void Update(Token token);
        void Remove(Token token);
        Token FindByUserId(TokenUserId tokenUserId);
        Token FindByUserIdAndHash(TokenUserId tokenUserId,TokenHash tokenHash);
    }
}
