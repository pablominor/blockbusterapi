using BlockbusterApp.src.Domain.UserAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTest.Stub.UserAggregate
{
    public class UserCountryCodeStub
    {

        public static UserCountryCode Create(string code)
        {
            return new UserCountryCode(code);
        }

        public static UserCountryCode ByDefault()
        {
            return new UserCountryCode("ES");
        }
    }
}
