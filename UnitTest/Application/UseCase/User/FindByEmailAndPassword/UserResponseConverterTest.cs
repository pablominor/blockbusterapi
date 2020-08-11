using BlockbusterApp.src.Application.UseCase.User.FindByEmalAndPassword;
using NUnit.Framework;
using UnitTest.Domain.UserAggregate.Stub;

namespace UnitTest.Application.UseCase.User.FindByEmailAndPassword
{
    [TestFixture]
    public class UserResponseConverterTest
    {
        [Test]
        public void ItShouldReturnCorrectResponse()
        {
            BlockbusterApp.src.Domain.UserAggregate.User user = UserStub.ByDefault();
            UserResponseConverter converter = new UserResponseConverter();

            var res = converter.Convert(user);

            Assert.IsInstanceOf<UserResponse>(res);
            UserResponse response = res as UserResponse;
            Assert.AreEqual(response.User.userId.GetValue(), user.userId.GetValue());
            Assert.AreEqual(response.User.userEmail.GetValue(), user.userEmail.GetValue());
            Assert.AreEqual(response.User.userFirstName.GetValue(), user.userFirstName.GetValue());
            Assert.AreEqual(response.User.userLastName.GetValue(), user.userLastName.GetValue());
            Assert.AreEqual(response.User.userRole.GetValue(), user.userRole.GetValue());
            Assert.AreEqual(response.User.userCountryCode.GetValue(), user.userCountryCode.GetValue());

        }

    }
}
