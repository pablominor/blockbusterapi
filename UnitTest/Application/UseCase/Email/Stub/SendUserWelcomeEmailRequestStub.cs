using BlockbusterApp.src.Application.UseCase.Email.SendUserWelcome;
using UnitTest.Domain.UserAggregate.Stub;
using UnitTest.Domain.UserAggregate.Stub;

namespace UnitTest.Application.UseCase.Email.Stub
{
    public class SendUserWelcomeEmailRequestStub
    {

        public static SendUserWelcomeEmailRequest Create(
            string Email,
            string FirstName,
            string LastName
            )
        {
            return new SendUserWelcomeEmailRequest(Email,FirstName,LastName);
        }

        public static SendUserWelcomeEmailRequest ByDefault()
        {
            return new SendUserWelcomeEmailRequest(
                UserEmailStub.ByDefault().GetValue(),
                UserFirstNameStub.ByDefault().GetValue(),
                UserLastNameStub.ByDefault().GetValue()
            );
        }

    }
}
