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
                ["user_id"] = user.userId.GetValue(),
                ["email"] = user.userEmail.GetValue(),
                ["first_name"] = user.userFirstName.GetValue(),
                ["last_name"] = user.userLastName.GetValue(),
                ["role"] = user.userRole.GetValue(),
            };
        }
    }
}
