using BlockbusterApp.src.Domain.UserAggregate;
using BlockbusterApp.src.Domain.UserAggregate.Service;
using BlockbusterApp.src.Domain.UserAggregate.Service.Exception;
using BlockbusterApp.src.Shared.Domain.Exception;
using Moq;
using NUnit.Framework;
using UnitTest.Domain.Repository;
using UnitTest.Domain.UserAggregate.Stub;

namespace UnitTest.Domain.UserAggregate.Service
{
    
    [TestFixture]
    public class UserFinderTest
    {

        private BlockbusterApp.src.Domain.UserAggregate.User userNull;
        
        [SetUp]
        public void Init()
        {
            userNull = null;
        }


        [Test]
        public void ItShouldThrowExceptionFromUserNotFoundById()
        {
            Mock<IUserRepository> userRepository = RepositoryStub.CreateUserRepository();
            userRepository.Setup(o => o.FindUserById(It.IsAny<UserId>())).Returns(this.userNull);
            UserFinder userFinder = new UserFinder(userRepository.Object);

            var Exception = Assert.Throws<UserNotFoundException>(() => userFinder.FindOneById(UserIdStub.ByDefault()));

            Assert.Pass(Exception.Message, UserNotFoundException.FromId(UserIdStub.ByDefault()));
            Assert.IsInstanceOf<ValidationException>(Exception);
        }

        [Test]
        public void ItShouldThrowExceptionFromUserNotFoundByEmailAndPassword()
        {
            Mock<IUserRepository> userRepository = RepositoryStub.CreateUserRepository();
            userRepository.Setup(o => o.FindUserByEmailAndPassword(It.IsAny<UserEmail>(), It.IsAny<UserHashedPassword>())).Returns(this.userNull);
            UserFinder userFinder = new UserFinder(userRepository.Object);

            var Exception = Assert.Throws<UserNotFoundException>(() => userFinder.ByEmailAndPassword(UserEmailStub.ByDefault(),UserPasswordStub.ByDefault()));

            Assert.Pass(Exception.Message, UserNotFoundException.FromEmailAndPassword());
            Assert.IsInstanceOf<ValidationException>(Exception);
        }

        [Test]
        public void ItShouldFindUserById()
        {
            BlockbusterApp.src.Domain.UserAggregate.User user = UserStub.ByDefault();
            Mock<IUserRepository> userRepository = RepositoryStub.CreateUserRepository();
            userRepository.Setup(o => o.FindUserById(It.IsAny<UserId>())).Returns(user);
            UserFinder userFinder = new UserFinder(userRepository.Object);

            var userFound = userFinder.FindOneById(UserIdStub.ByDefault());

            Assert.IsNotNull(userFound);
            Assert.IsInstanceOf<BlockbusterApp.src.Domain.UserAggregate.User>(userFound);            
        }

        [Test]
        public void ItShouldFindUserByEmailAndPassword()
        {
            BlockbusterApp.src.Domain.UserAggregate.User user = UserStub.ByDefault();
            Mock<IUserRepository> userRepository = RepositoryStub.CreateUserRepository();
            userRepository.Setup(o => o.FindUserByEmailAndPassword(It.IsAny<UserEmail>(), It.IsAny<UserHashedPassword>())).Returns(user);
            UserFinder userFinder = new UserFinder(userRepository.Object);

            var userFound = userFinder.ByEmailAndPassword(UserEmailStub.ByDefault(),UserPasswordStub.ByDefault());

            Assert.IsNotNull(userFound);
            Assert.IsInstanceOf<BlockbusterApp.src.Domain.UserAggregate.User>(userFound);
        }

    }
}
