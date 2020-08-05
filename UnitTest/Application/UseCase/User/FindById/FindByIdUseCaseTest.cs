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
            Mock<FindUserResponseConverter> converter = new Mock<FindUserResponseConverter>();
            converter.Setup(o => o.Convert(user));
            Mock<IUserAuthorization> userAuthorization = new Mock<IUserAuthorization>();
            userAuthorization.Setup(o => o.AuthorizeAsOwner(It.IsAny<UserId>()));
            FindUserByIdUseCase useCase = new FindUserByIdUseCase(converter.Object, userFinder.Object,userAuthorization.Object);

            useCase.Execute(request);

            userAuthorization.VerifyAll();
            userFinder.VerifyAll();
            converter.VerifyAll();
        }
    }
}
