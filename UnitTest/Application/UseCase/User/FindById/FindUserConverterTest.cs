using BlockbusterApp.src.Application.UseCase.User.Response;
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
            Assert.AreEqual(response.Id, user.userId.GetValue());
            Assert.AreEqual(response.Email, user.userEmail.GetValue());
            Assert.AreEqual(response.FirstName, user.userFirstName.GetValue());
            Assert.AreEqual(response.LastName, user.userLastName.GetValue());
            Assert.AreEqual(response.Role, user.userRole.GetValue());
            Assert.AreEqual(response.CountryCode, user.userCountryCode.GetValue());

        }



    }
}
