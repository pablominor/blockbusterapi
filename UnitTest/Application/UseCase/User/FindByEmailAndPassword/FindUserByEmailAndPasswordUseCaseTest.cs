using BlockbusterApp.src.Application.UseCase.User.FindByEmalAndPassword;
using BlockbusterApp.src.Application.UseCase.User.Response;
using BlockbusterApp.src.Domain.UserAggregate;
using BlockbusterApp.src.Domain.UserAggregate.Service;
using BlockbusterApp.src.Infraestructure.Service.Hashing;
using Moq;
using NUnit.Framework;
using UnitTest.Application.UseCase.User.FindById;
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
            Mock<UserFinder> userFinder = UserFinderStub.ByDefault();
            userFinder.Setup(o => o.ByEmailAndPassword(It.IsAny<UserEmail>(), It.IsAny<UserHashedPassword>()));
            Mock<FindUserResponseConverter> converter = new Mock<FindUserResponseConverter>();
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
    }
}
