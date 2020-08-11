using BlockbusterApp.src.Shared.Infraestructure.Security.Authentication.JWT;
using System.Collections.Generic;
using UnitTest.Domain.UserAggregate.Stub;

namespace UnitTest.Domain.TokenAggregate.Stub
{
    public class PayloadStub
    {

        public static Dictionary<string, string> ByDefault()
        {
            return new Dictionary<string, string>()
            {
                [TokenClaimTypes.USER_ID] = UserIdStub.ByDefault().GetValue(),
                [TokenClaimTypes.EMAIL] = UserEmailStub.ByDefault().GetValue(),
                [TokenClaimTypes.FIRST_NAME] = UserFirstNameStub.ByDefault().GetValue(),
                [TokenClaimTypes.LAST_NAME] = UserLastNameStub.ByDefault().GetValue(),
                [TokenClaimTypes.ROLE] = UserRoleStub.CreateLikeAdmin().GetValue()
            };
        }
       
    }
}
