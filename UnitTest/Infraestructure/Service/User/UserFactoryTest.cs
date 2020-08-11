using BlockbusterApp.src.Domain.CountryAggregate;
using BlockbusterApp.src.Domain.CountryAggregate.Service;
using BlockbusterApp.src.Domain.UserAggregate;
using BlockbusterApp.src.Infraestructure.Service.Hashing;
using BlockbusterApp.src.Infraestructure.Service.User;
using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using BlockbusterApp.src.Shared.Infraestructure.Bus.UseCase;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using UnitTest.Domain.UserAggregate.Stub;
using UnitTest.Shared.Application.Bus.UseCase;

namespace UnitTest.Infraestructure.Service.User
{
    [TestFixture]
    class UserFactoryTest
    {

        [Test]
        public void ItShouldCreateAnUser()
        {
            Mock<IHashing> hasing = CreateHashingMock();
            Mock<IUseCaseBus> useCaseBus = UseCaseBusMockGenerator.CreateUseCaseBusThatDispatchAnyRequest();
            UserFactory userFactory = new UserFactory(hasing.Object,useCaseBus.Object);

            BlockbusterApp.src.Domain.UserAggregate.User user = userFactory.Create(
                UserIdStub.ByDefault().GetValue(),
                UserEmailStub.ByDefault().GetValue(),
                UserPasswordStub.ByDefault().GetValue(),
                UserPasswordStub.ByDefault().GetValue(),
                UserFirstNameStub.ByDefault().GetValue(),
                UserLastNameStub.ByDefault().GetValue(),
                UserRoleStub.CreateLikeUser().GetValue(),
                UserCountryCodeStub.ByDefault().GetValue());


            Assert.IsTrue(user.userId.Equals(UserIdStub.ByDefault()));
            Assert.IsTrue(user.userEmail.Equals(UserEmailStub.ByDefault()));
            Assert.IsTrue(user.userHashedPassword.Equals(UserPasswordStub.ByDefault()));
            Assert.IsTrue(user.userFirstName.Equals(UserFirstNameStub.ByDefault()));
            Assert.IsTrue(user.userLastName.Equals(UserLastNameStub.ByDefault()));
            Assert.IsTrue(user.userRole.Equals(UserRoleStub.CreateLikeUser()));
            Assert.IsTrue(user.userCountryCode.Equals(UserCountryCodeStub.ByDefault()));
        }

        [Test]
        public void ItShouldCallCollaborators()
        {
            Mock<IHashing> hasing = CreateHashingMock();
            Mock<IUseCaseBus> useCaseBus = UseCaseBusMockGenerator.CreateUseCaseBusThatDispatchAnyRequest();
            UserFactory userFactory = new UserFactory(hasing.Object, useCaseBus.Object);

            BlockbusterApp.src.Domain.UserAggregate.User user = userFactory.Create(
                UserIdStub.ByDefault().GetValue(),
                UserEmailStub.ByDefault().GetValue(),
                UserPasswordStub.ByDefault().GetValue(),
                UserPasswordStub.ByDefault().GetValue(),
                UserFirstNameStub.ByDefault().GetValue(),
                UserLastNameStub.ByDefault().GetValue(),
                UserRoleStub.CreateLikeUser().GetValue(),
                UserCountryCodeStub.ByDefault().GetValue());


            hasing.VerifyAll();
            useCaseBus.VerifyAll();
        }

        private Mock<IHashing> CreateHashingMock()
        {
            Mock<IHashing> hasing = new Mock<IHashing>();
            hasing.Setup(o => o.Hash(It.IsAny<string>())).Returns(UserPasswordStub.ByDefault());
            return hasing;
        }

    }
}
