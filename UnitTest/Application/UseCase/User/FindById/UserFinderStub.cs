using BlockbusterApp.src.Domain.UserAggregate;
using BlockbusterApp.src.Domain.UserAggregate.Service;
using Moq;
using UnitTest.Domain.Repository;

namespace UnitTest.Application.UseCase.User.FindById
{
    public class UserFinderStub
    {
        public static Mock<UserFinder> ByDefault()
        {
            Mock<IUserRepository> userRepository = RepositoryStub.CreateUserRepository();
            Mock<UserFinder> userFinder = new Mock<UserFinder>(userRepository.Object);
            return userFinder;
        }

    }
}
