using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Domain.TokenAggregate
{
    public interface ITokenFactory
    {
        Token Create(Dictionary<string,string> payload);
    }
}
