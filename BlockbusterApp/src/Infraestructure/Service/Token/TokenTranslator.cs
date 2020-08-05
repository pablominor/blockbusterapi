using BlockbusterApp.src.Shared.Infraestructure.Security.Authentication.JWT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Infraestructure.Service.Token
{
    public class TokenTranslator
    {

        public Dictionary<string,string> FromRepresentationToPayLoad(Domain.UserAggregate.User user)
        {
            return new Dictionary<string, string>()
            {
                [TokenClaimTypes.USER_ID] = user.userId.GetValue(),
                [TokenClaimTypes.EMAIL] = user.userEmail.GetValue(),
                [TokenClaimTypes.FIRST_NAME] = user.userFirstName.GetValue(),
                [TokenClaimTypes.LAST_NAME] = user.userLastName.GetValue(),
                [TokenClaimTypes.ROLE] = user.userRole.GetValue(),
            };
        }
    }
}
