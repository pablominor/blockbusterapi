using BlockbusterApp.src.Application.UseCase.User.Update;
using UnitTest.Domain.UserAggregate.Stub;

namespace UnitTest.Application.UseCase.User.Update.Stub
{
    public class UpdateUserRequestStub
    {

        public static UpdateUserRequest Create(
            string id,
            string Password,
            string FirstName,
            string LastName)
        {
            UpdateUserRequest request = new UpdateUserRequest(Password, FirstName, LastName);
            request.Id = id;
            return request;
        }

        public static UpdateUserRequest ByDefault()
        {
            UpdateUserRequest request = new UpdateUserRequest(
                UserPasswordStub.ByDefault().GetValue(),
                UserFirstNameStub.ByDefault().GetValue(),
                UserLastNameStub.ByDefault().GetValue()
            );
            request.Id = UserIdStub.ByDefault().GetValue();
            return request;
        }

    }
}
