using BlockbusterApp.src.Application.UseCase.User.FindById;
using System;
using System.Collections.Generic;
using System.Text;
using UnitTest.Domain.UserAggregate.Stub;

namespace UnitTest.Application.UseCase.User.FindById
{
    public class FindUserByIdRequestStub
    {
        public static FindUserByIdRequest Create(
            string Id
            )
        {
            return new FindUserByIdRequest(Id);
        }

        public static FindUserByIdRequest ByDefault()
        {
            return new FindUserByIdRequest(
                UserIdStub.ByDefault().GetValue()                
            );
        }
    }
}
