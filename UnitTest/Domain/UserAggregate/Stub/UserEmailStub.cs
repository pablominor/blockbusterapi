using BlockbusterApp.src.Domain.UserAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace  UnitTest.Domain.UserAggregate.Stub
{
    public class UserEmailStub
    {

        public static UserEmail Crate(string email)
        {
            return new UserEmail(email);
        }

        public static UserEmail ByDefault()
        {
            return new UserEmail("blockbuster@mail.com");
        }
    }
}
