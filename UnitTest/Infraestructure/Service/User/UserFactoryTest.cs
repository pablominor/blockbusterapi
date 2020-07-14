using BlockbusterApp.src.Domain.UserAggregate;
using BlockbusterApp.src.Infraestructure.Service.Hashing;
using BlockbusterApp.src.Infraestructure.Service.User;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using UnitTest.Stub.UserAggregate;

namespace UnitTest.Infraestructure.Service.User
{
    [TestFixture]
    class UserFactoryTest
    {

        [Test]
        public void ItShouldCreateAnUser()
        {
            Mock<IHashing> hasing = new Mock<IHashing>();
            hasing.Setup(o => o.Hash(It.IsAny<string>())).Returns(UserPasswordStub.ByDefault());
            UserFactory userFactory = new UserFactory(hasing.Object);

            BlockbusterApp.src.Domain.UserAggregate.User user = userFactory.Create(
                UserIdStub.ByDefault().GetValue(),
                UserEmailStub.ByDefault().GetValue(),
                UserPasswordStub.ByDefault().GetValue(),
                UserPasswordStub.ByDefault().GetValue(),
                UserFirstNameStub.ByDefault().GetValue(),
                UserLastNameStub.ByDefault().GetValue(),
                UserRoleStub.CreateLikeUser().GetValue());


            Assert.IsTrue(user.userId.Equals(UserIdStub.ByDefault()));
            Assert.IsTrue(user.userEmail.Equals(UserEmailStub.ByDefault()));
            Assert.IsTrue(user.userHashedPassword.Equals(UserPasswordStub.ByDefault()));
            Assert.IsTrue(user.userFirstName.Equals(UserFirstNameStub.ByDefault()));
            Assert.IsTrue(user.userLastName.Equals(UserLastNameStub.ByDefault()));
            Assert.IsTrue(user.userRole.Equals(UserRoleStub.CreateLikeUser()));
        }
    }
}
