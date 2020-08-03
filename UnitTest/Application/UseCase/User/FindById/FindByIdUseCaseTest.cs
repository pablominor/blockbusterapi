using BlockbusterApp.src.Application.UseCase.User.FindById;
using BlockbusterApp.src.Domain.UserAggregate;
using BlockbusterApp.src.Domain.UserAggregate.Service;
using Moq;
using NUnit.Framework;
using UnitTest.Stub.UserAggregate;

namespace UnitTest.Application.UseCase.User.FindById
{
    [TestFixture]
    public class FindByIdUseCaseTest
    {

        [Test]
        public void ItShouldCallCollaborators()
        {
            FindUserByIdRequest request = FindUserByIdRequestStub.ByDefault();
            BlockbusterApp.src.Domain.UserAggregate.User user = UserStub.ByDefault();
            Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
            Mock<UserFinder> userFinder = new Mock<UserFinder>(userRepository.Object);
            userFinder.Setup(o => o.ById(It.IsAny<UserId>())).Returns(user);
            Mock<FindUserConverter> converter = new Mock<FindUserConverter>();
            converter.Setup(o => o.Convert(user));
            FindUserByIdUseCase useCase = new FindUserByIdUseCase(converter.Object, userFinder.Object);

            useCase.Execute(request);

            userFinder.VerifyAll();
            converter.VerifyAll();            
        }
    }
}
