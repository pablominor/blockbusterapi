using BlockbusterApp.src.Domain.UserAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTest.Stub.UserAggregate
{
    public class UserFirstNameStub
    {

        public static UserFirstName Crate(string firstName)
        {
            return new UserFirstName(firstName);
        }

        public static UserFirstName ByDefault()
        {
            return new UserFirstName("blockbuster");
        }
    }
}
