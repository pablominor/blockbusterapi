using BlockbusterApp.src.Shared.Domain;

namespace BlockbusterApp.src.Domain.UserAggregate
{
    public class UserCountryCode : StringValueObject
    {       
        public UserCountryCode(string value) : base(value){}
    }
}
