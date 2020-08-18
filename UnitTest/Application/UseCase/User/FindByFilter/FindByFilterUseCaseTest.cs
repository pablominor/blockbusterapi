using BlockbusterApp.src.Application.UseCase.User.FindByFilter;
using BlockbusterApp.src.Application.UseCase.User.FindById;
using BlockbusterApp.src.Domain.UserAggregate;
using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using BlockbusterApp.src.Shared.Application.Bus.UseCase.Response;
using Microsoft.AspNetCore.Http;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using UnitTest.Domain.Repository;

namespace UnitTest.Application.UseCase.User.FindByFilter
{
    [TestFixture]
    public class FindByFilterUseCaseTest
    {

        [Test]
        public void ItShouldCallCollaborators()
        {
            Mock<IQueryCollection> query = new Mock<IQueryCollection>();
            Mock<GetUsersRequest> request = new Mock<GetUsersRequest>(query.Object);
            Mock<IUserRepository> userRepository = RepositoryStub.CreateUserRepository();
            userRepository.Setup(o => o.GetUsers(It.IsAny<Dictionary<string,int>>()));
            Mock<GetUsersConverter> converter = new Mock<GetUsersConverter>();
            converter.Setup(o => o.Convert(It.IsAny<IEnumerable<dynamic>>())).Returns(new CollectionResponse<IResponse>());
            GetUsersUseCase useCase = new GetUsersUseCase(userRepository.Object, converter.Object);

            useCase.Execute(request.Object);

            userRepository.VerifyAll();
            converter.VerifyAll();
        }


    }
}
