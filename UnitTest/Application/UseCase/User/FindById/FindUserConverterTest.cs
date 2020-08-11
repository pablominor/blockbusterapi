using BlockbusterApp.src.Application.UseCase.User.FindById;
using NUnit.Framework;
using UnitTest.Domain.UserAggregate.Stub;

namespace UnitTest.Application.UseCase.User.FindById
{
    [TestFixture]
    public class FindUserConverterTest
    {

        [Test]
        public void ItShouldReturnCorrectResponse()
        {
            BlockbusterApp.src.Domain.UserAggregate.User user = UserStub.ByDefault();
            FindUserResponseConverter findUserConverter = new FindUserResponseConverter();
            
            var res = findUserConverter.Convert(user);

            Assert.IsInstanceOf<FindUserResponse>(res);
            FindUserResponse response = res as FindUserResponse;
            Assert.AreEqual(response.id, user.userId.GetValue());
            Assert.AreEqual(response.email, user.userEmail.GetValue());
            Assert.AreEqual(response.firstName, user.userFirstName.GetValue());
            Assert.AreEqual(response.lastName, user.userLastName.GetValue());
            Assert.AreEqual(response.role, user.userRole.GetValue());
            Assert.AreEqual(response.countryCode, user.userCountryCode.GetValue());

        }



    }
}
