using BlockbusterApp.src.Shared.Infraestructure.Security.Authentication.JWT;
using System.Collections.Generic;

namespace BlockbusterApp.src.Infraestructure.Service.Token
{
    public class TokenTranslator
    {

        public Dictionary<string,string> FromRepresentationToPayLoad(dynamic user)
        {
            return new Dictionary<string, string>()
            {
                [TokenClaimTypes.USER_ID] = user.Id,
                [TokenClaimTypes.EMAIL] = user.Email,
                [TokenClaimTypes.FIRST_NAME] = user.FirstName,
                [TokenClaimTypes.LAST_NAME] = user.LastName,
                [TokenClaimTypes.ROLE] = user.Role,
            };
        }
    }
}
