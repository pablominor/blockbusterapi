using BlockbusterApp.src.Domain.TokenAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTest.Domain.TokenAggregate.Stub
{
    public class TokenHashStub
    {

        public static TokenHash Crate(string hash)
        {
            return new TokenHash(hash);
        }

        public static TokenHash ByDefault()
        {
            return new TokenHash("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VyX2lkIjoiMTMwMTdlYmUtZDYyZC0xMWVhLTg3ZDAtMDI0MmFjMTMwMDAzIiwiZW1haWwiOiJwYWJsbzN2aWFzQGdtYWlsLmNvbSIsImZpcnN0X25hbWUiOiJQYWJsbyIsImxhc3RfbmFtZSI6Ik1pw7FvciIsInJvbGUiOiJBZG1pbiIsIm5iZiI6MTU5NjUzNDMzNCwiZXhwIjoxNTk3MTM5MTM0LCJpYXQiOjE1OTY1MzQzMzR9.GF8Tg_CQvYxOXBL-K4g8Z9ueHZyaEY87NuxNx6P_aFc");
        }
    }
}
