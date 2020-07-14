using BlockbusterApp.src.Domain.UserAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTest.Stub.UserAggregate
{
    public class UserIdStub
    {

        public static UserId Crate(string id)
        {
            return new UserId(id);
        }

        public static UserId ByDefault()
        {
            return new UserId("a742aea9-1923-45bd-903e-b0210436d6c2");
        }
    }
}
