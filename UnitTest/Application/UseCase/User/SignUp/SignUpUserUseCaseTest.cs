using BlockbusterApp.src.Application.UseCase.User.SignUP;
using BlockbusterApp.src.Domain.CountryAggregate;
using BlockbusterApp.src.Domain.UserAggregate;
using BlockbusterApp.src.Domain.UserAggregate.Service;
using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using BlockbusterApp.src.Shared.Domain.Event;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using UnitTest.Domain.UserAggregate.Stub;
using UnitTest.Application.UseCase.User.SignUp.Stub;
using UnitTest.Domain.Repository;

namespace UnitTest.Application.UseCase.User.SignUp
{
    [TestFixture]
    public class SignUpUserUseCaseTest
    {

        [Test]
        public void ItShouldCallCollaborators()
        {            
            SignUpUserRequest request = SignUpUserRequestStub.ByDefault();
            BlockbusterApp.src.Domain.UserAggregate.User user = UserStub.ByDefault();
            Mock<IUserFactory> userFactory = new Mock<IUserFactory>();
            userFactory.Setup(o => o.Create(
                request.Id,
                request.Email,
                request.Password,
                request.RepeatPassword,
                request.FirstName,
                request.LastName,
                request.Role,
                request.CountryCode))
                .Returns(user);
            Mock<IEventProvider> eventProvider = new Mock<IEventProvider>();
            eventProvider.Setup(o => o.RecordEvents(It.IsAny<List<DomainEvent>>()));
            Mock<IUserRepository> userRepository = RepositoryStub.CreateUserRepository();
            userRepository.Setup(o => o.Add(user));
            Mock<SignUpUserValidator> signUpUserValidator = new Mock<SignUpUserValidator>(userRepository.Object);
            signUpUserValidator.Setup(o => o.Validate(It.IsAny<UserEmail>()));
            Mock<ICountryRepository> countryRepository = new Mock<ICountryRepository>();
            Mock<EmptyResponseConverter> emptyResponseConverter = new Mock<EmptyResponseConverter>();
            emptyResponseConverter.Setup(o => o.Convert());
            SignUpUserUseCase useCase = new SignUpUserUseCase(
                userFactory.Object,
                signUpUserValidator.Object,
                userRepository.Object,
                emptyResponseConverter.Object,
                eventProvider.Object
                );

            useCase.Execute(request);

            userFactory.VerifyAll();
            signUpUserValidator.VerifyAll();
            userRepository.VerifyAll();
            emptyResponseConverter.VerifyAll();
            eventProvider.VerifyAll();
        }
    }
}
