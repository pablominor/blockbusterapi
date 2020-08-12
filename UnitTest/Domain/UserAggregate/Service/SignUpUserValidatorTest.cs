using BlockbusterApp.src.Domain.UserAggregate;
using BlockbusterApp.src.Domain.UserAggregate.Service;
using BlockbusterApp.src.Domain.UserAggregate.Service.Exception;
using Moq;
using NUnit.Framework;
using UnitTest.Domain.Repository;
using UnitTest.Domain.UserAggregate.Stub;

namespace UnitTest.Domain.UserAggregate.Service
{
    [TestFixture]
    class SignUpUserValidatorTest
    {

        [Test]
        public void ItShouldThrowExceptionWhenFindUserWithSameEmail()
        {
            Mock<IUserRepository> userRepository = RepositoryStub.CreateUserRepository();
            userRepository.Setup(o => o.FindUserByEmail(UserEmailStub.ByDefault())).Returns(UserStub.ByDefault());
            SignUpUserValidator signUpUserValidator = new SignUpUserValidator(userRepository.Object);

            var Exception = Assert.Throws<UserFoundException>(() => signUpUserValidator.Validate(UserEmailStub.ByDefault()));

            Assert.Pass(Exception.Message, UserFoundException.FromEmail(UserEmailStub.ByDefault()));
        }

        [Test]
        public void ItShouldValidateAnCallCollaborators()
        {
            Mock<IUserRepository> userRepository = RepositoryStub.CreateUserRepository();
            userRepository.Setup(o => o.FindUserByEmail(It.IsAny<UserEmail>()));
            SignUpUserValidator signUpUserValidator = new SignUpUserValidator(userRepository.Object);

            signUpUserValidator.Validate(UserEmailStub.ByDefault());

            userRepository.VerifyAll();
        }

    }
}
