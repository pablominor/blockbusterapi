using BlockbusterApp.src.Application.UseCase.User.FindByEmalAndPassword;
using BlockbusterApp.src.Domain.UserAggregate;
using BlockbusterApp.src.Domain.UserAggregate.Service;
using BlockbusterApp.src.Infraestructure.Service.Hashing;
using Moq;
using NUnit.Framework;
using UnitTest.Domain.Repository;
using UnitTest.Domain.UserAggregate.Stub;

namespace UnitTest.Application.UseCase.User.FindByEmailAndPassword
{
    [TestFixture]
    public class FindUserByEmailAndPasswordUseCaseTest
    {

        [Test]
        public void ItShouldCallCollaborators()
        {
            FindUserByEmailAndPasswordRequest request = FindUserByEmailAndPasswordRequestStub.ByDefault();
            Mock<UserFinder> userFinder = CreateUserFinderMock();
            userFinder.Setup(o => o.ByEmailAndPassword(It.IsAny<UserEmail>(), It.IsAny<UserHashedPassword>()));
            Mock<UserResponseConverter> converter = new Mock<UserResponseConverter>();
            converter.Setup(o => o.Convert(It.IsAny<BlockbusterApp.src.Domain.UserAggregate.User>()));            
            Mock<IHashing> hashing = new Mock<IHashing>();
            hashing.Setup(o => o.Hash(It.IsAny<string>()));
            FindUserByEmailAndPasswordUseCase useCase = new FindUserByEmailAndPasswordUseCase(
                userFinder.Object, 
                hashing.Object, 
                converter.Object);

            useCase.Execute(request);

            userFinder.VerifyAll();
            hashing.VerifyAll();
            converter.VerifyAll();
        }

        private Mock<UserFinder> CreateUserFinderMock()
        {
            Mock<IUserRepository> userRepository = RepositoryMockGenerator.CreateUserRepository();
            Mock<UserFinder> userFinder = new Mock<UserFinder>(userRepository.Object);
            return userFinder;
        }

    }
}
