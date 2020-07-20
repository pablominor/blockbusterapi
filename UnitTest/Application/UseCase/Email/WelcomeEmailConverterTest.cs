using BlockbusterApp.src.Application.UseCase.Email.SendUserWelcome;
using NUnit.Framework;

namespace UnitTest.Application.UseCase.Email
{
    [TestFixture]
    public class WelcomeEmailConverterTest
    {

        [Test]
        public void ItShouldReturnSendUserWelcomeEmailResponse()
        {
            WelcomeEmailConverter welcomeEmailConverter = new WelcomeEmailConverter();

            var response = welcomeEmailConverter.Convert();

            Assert.IsInstanceOf<SendUserWelcomeEmailResponse>(response);
        }
    }
}
