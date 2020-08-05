using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Shared.Infraestructure.Security.Authentication.JWT
{
    public static class TokenClaimTypes
    {
        public const string USER_ID = "user_id";
        public const string EMAIL = "email";
        public const string FIRST_NAME = "first_name";
        public const string LAST_NAME = "last_name";
        public const string ROLE = "role";

    }
}
