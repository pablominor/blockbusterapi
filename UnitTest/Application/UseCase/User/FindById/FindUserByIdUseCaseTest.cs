using BlockbusterApp.src.Application.UseCase.User.FindById;
using BlockbusterApp.src.Domain.UserAggregate;
using BlockbusterApp.src.Domain.UserAggregate.Service;
using BlockbusterApp.src.Shared.Infraestructure.Security.Authentication.JWT;
using Moq;
using NUnit.Framework;
using UnitTest.Domain.UserAggregate.Stub;
using UnitTest.Shared.Infraestructure.Security.Authentication.JWT;

namespace UnitTest.Application.UseCase.User.FindById
{
    [TestFixture]
    public class FindUserByIdUseCaseTest
    {

        [Test]
        public void ItShouldCallCollaborators()
        {
            FindUserByIdRequest request = FindUserByIdRequestStub.ByDefault();
            BlockbusterApp.src.Domain.UserAggregate.User user = UserStub.ByDefault();
            Mock<UserFinder> userFinder = UserFinderStub.ByDefault();
            userFinder.Setup(o => o.ById(It.IsAny<UserId>())).Returns(user);
            Mock<FindUserResponseConverter> converter = new Mock<FindUserResponseConverter>();
            converter.Setup(o => o.Convert(user));            
            FindUserByIdUseCase useCase = new FindUserByIdUseCase(converter.Object, userFinder.Object);

            useCase.Execute(request);

            userFinder.VerifyAll();
            converter.VerifyAll();
        }
    }
}
