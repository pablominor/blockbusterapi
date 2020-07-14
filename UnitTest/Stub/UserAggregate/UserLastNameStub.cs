using BlockbusterApp.src.Domain.UserAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTest.Stub.UserAggregate
{
    public class UserLastNameStub
    {

        public static UserLastName Crate(string lastName)
        {
            return new UserLastName(lastName);
        }

        public static UserLastName ByDefault()
        {
            return new UserLastName("app fernandez");
        }
    }
}
