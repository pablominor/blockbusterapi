using BlockbusterApp.src.Domain.UserAggregate.Event;
using BlockbusterApp.src.Shared.Domain.Event;
using System;
using System.Collections.Generic;
using System.Text;
using UnitTest.Domain.UserAggregate.Stub;

namespace UnitTest.Application.Event.User
{
    public class SendWelcomeEmailDomainEventStub
    {

        public static DomainEvent ByDefault()
        {
            return new UserSignedUpEvent(UserIdStub.ByDefault().GetValue(),
                new Dictionary<string, string>
                {
                    ["email"] = UserEmailStub.ByDefault().GetValue(),
                    ["firstname"] = UserFirstNameStub.ByDefault().GetValue(),
                    ["lastname"] = UserLastNameStub.ByDefault().GetValue(),
                    ["role"] = UserRoleStub.CreateLikeUser().GetValue(),
                    ["country_code"] = UserCountryCodeStub.ByDefault().GetValue()
                }
            );
        }
    }
}
