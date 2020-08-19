using BlockbusterApp.src.Domain.UserAggregate;

namespace  UnitTest.Domain.UserAggregate.Stub
{
    public class UserPasswordStub
    {

        public static UserHashedPassword Create(string password)
        {
            return new UserHashedPassword(password);
        }

        public static UserHashedPassword ByDefault()
        {
            return new UserHashedPassword("Craftcode3");
        }
    }
}
