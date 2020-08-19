using BlockbusterApp.src.Application.UseCase.User.Update;
using BlockbusterApp.src.Domain.UserAggregate;
using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using Moq;
using NUnit.Framework;
using UnitTest.Application.UseCase.User.Update.Stub;
using UnitTest.Domain.Repository;
using UnitTest.Domain.UserAggregate.Stub;

namespace UnitTest.Application.UseCase.User.Update
{
    [TestFixture]
    public class UpdateUserUseCaseTest
    {

        [Test]
        public void ItShouldCallCollaborators()
        {
            UpdateUserRequest request = UpdateUserRequestStub.ByDefault();
            BlockbusterApp.src.Domain.UserAggregate.User user = UserStub.ByDefault();
            Mock<IUserUpdater> userUpdater = new Mock<IUserUpdater>();
            userUpdater.Setup(o => o.Update(request.Id, request.Password, request.FirstName, request.LastName)).Returns(user);
            Mock<IUserRepository> userRepository = RepositoryStub.CreateUserRepository();
            userRepository.Setup(o => o.Update(user));
            Mock<EmptyResponseConverter> converter = new Mock<EmptyResponseConverter>();
            converter.Setup(o => o.Convert());
            UpdateUserUseCase useCase = new UpdateUserUseCase(userUpdater.Object, userRepository.Object, converter.Object);
           
            useCase.Execute(request);

            userUpdater.VerifyAll();
            userRepository.VerifyAll();
            converter.VerifyAll();
        }
    }
}
