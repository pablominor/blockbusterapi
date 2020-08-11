using BlockbusterApp.src.Domain.UserAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace  UnitTest.Domain.UserAggregate.Stub
{
    public class UserPasswordStub
    {

        public static UserHashedPassword Crate(string password)
        {
            return new UserHashedPassword(password);
        }

        public static UserHashedPassword ByDefault()
        {
            return new UserHashedPassword("Craftcode3");
        }
    }
}
