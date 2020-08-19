namespace BlockbusterApp.src.Domain.UserAggregate
{
    public interface IUserUpdater
    {
        User Update(
            string id,
            string password,
            string firstName,
            string lastName);
    }
}
