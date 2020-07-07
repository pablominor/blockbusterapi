using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Shared.Infraestructure.Security.Authentication.JWT
{
    public interface IJWTEncoder
    {
        string Encode(Dictionary<string, string> payload);
    }
}
