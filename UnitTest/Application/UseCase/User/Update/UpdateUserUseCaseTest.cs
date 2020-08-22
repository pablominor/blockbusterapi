using BlockbusterApp.src.Application.UseCase.User.Response;
using BlockbusterApp.src.Application.UseCase.User.Update;
using BlockbusterApp.src.Domain.UserAggregate;
using BlockbusterApp.src.Domain.UserAggregate.Service;
using BlockbusterApp.src.Infraestructure.Service.Hashing;
using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using Moq;
using NUnit.Framework;
using System.Buffers.Text;
using UnitTest.Application.UseCase.User.FindById;
using UnitTest.Application.UseCase.User.Update.Stub;
using UnitTest.Domain.Repository;
using UnitTest.Domain.UserAggregate.Stub;
using UnitTest.Infraestructure.Service.User;

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
            Mock<UserFinder> userFinder = UserFinderStub.ByDefault();
            userFinder.Setup(o => o.FindOneById(It.IsAny<UserId>())).Returns(user);
            Mock<IHashing> hashing = HashingStub.ByDefault();
            Mock<IUserRepository> userRepository = RepositoryStub.CreateUserRepository();
            userRepository.Setup(o => o.Update(user));
            Mock<EmptyResponseConverter> converter = new Mock<EmptyResponseConverter>();
            converter.Setup(o => o.Convert());
            UpdateUserUseCase useCase = new UpdateUserUseCase(userFinder.Object, userRepository.Object, converter.Object,hashing.Object);
           
            useCase.Execute(request);

            userFinder.VerifyAll();
            hashing.VerifyAll();
            userRepository.VerifyAll();
            converter.VerifyAll();
        }
    }
}
