using BlockbusterApp.src.Infraestructure.Service.Hashing;
using Moq;
using UnitTest.Domain.UserAggregate.Stub;

namespace UnitTest.Infraestructure.Service.User
{
    public class HashingStub
    {
        public static Mock<IHashing> ByDefault()
        {
            Mock<IHashing> hasing = new Mock<IHashing>();
            hasing.Setup(o => o.Hash(It.IsAny<string>())).Returns(UserPasswordStub.ByDefault());
            return hasing;
        }

    }
}
