using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Application.UseCase.Token.Response
{
    public class Token
    {
        public string Type { get; set; } = "token";
        public string Hash { get; set; }
    }
}
