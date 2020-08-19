using BlockbusterApp.src.Domain.UserAggregate;
using BlockbusterApp.src.Domain.UserAggregate.Service;
using BlockbusterApp.src.Infraestructure.Service.Hashing;
using BlockbusterApp.src.Infraestructure.Service.User;
using Moq;
using NUnit.Framework;
using UnitTest.Application.UseCase.User.FindById;
using UnitTest.Domain.UserAggregate.Stub;

namespace UnitTest.Infraestructure.Service.User
{
    [TestFixture]
    public class UserUpdaterTest
    {

        [Test]
        public void ItShouldCallCollaborators()
        {
            Mock<IHashing> hasing = HashingStub.ByDefault();
            BlockbusterApp.src.Domain.UserAggregate.User user = UserStub.ByDefault();
            Mock<UserFinder> userFinder = UserFinderStub.ByDefault();
            userFinder.Setup(o => o.ById(It.IsAny<UserId>())).Returns(user);
            UserUpdater userUpdater = new UserUpdater(userFinder.Object,hasing.Object);

            userUpdater.Update(
                UserIdStub.ByDefault().GetValue(),
                UserPasswordStub.ByDefault().GetValue(),
                UserFirstNameStub.ByDefault().GetValue(),
                UserLastNameStub.ByDefault().GetValue());


            hasing.VerifyAll();
            userFinder.VerifyAll();
        }

        [TestCase("CreafCode1$","Manuel","Rodriguez")]
        [TestCase("CreafCode%/", "Prueba", "Update")]
        [TestCase("CreafCode6/2", "David", "Perez Lopez")]
        public void ItShouldCreateAnUser(string password, string firstName, string lastName)
        {
            Mock<IHashing> hasing = new Mock<IHashing>();
            hasing.Setup(o => o.Hash(It.IsAny<string>())).Returns(UserPasswordStub.Create(password));
            BlockbusterApp.src.Domain.UserAggregate.User user = UserStub.ByDefault();
            Mock<UserFinder> userFinder = UserFinderStub.ByDefault();
            userFinder.Setup(o => o.ById(It.IsAny<UserId>())).Returns(user);
            UserUpdater userUpdater = new UserUpdater(userFinder.Object, hasing.Object);

            BlockbusterApp.src.Domain.UserAggregate.User userUpdated = userUpdater.Update(
                UserIdStub.ByDefault().GetValue(),
                password,
                firstName,
                lastName);


            Assert.AreEqual(user.userHashedPassword.GetValue(),password);
            Assert.AreEqual(user.userFirstName.GetValue(),firstName);
            Assert.AreEqual(user.userLastName.GetValue(),lastName);
        }
    }
}
