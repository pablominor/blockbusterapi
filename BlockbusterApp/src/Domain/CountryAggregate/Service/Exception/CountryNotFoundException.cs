using BlockbusterApp.src.Shared.Domain.Exception;
using System;

namespace BlockbusterApp.src.Domain.CountryAggregate.Service.Exception
{
    public class CountryNotFoundException : ValidationException
    {
        public CountryNotFoundException(string value) : base(value) { }

        public static CountryNotFoundException Fromcode(CountryCode countryCode)
        {
            return new CountryNotFoundException(String.Format("Country with code {0} doesn't exists.", countryCode.GetValue()));
        }
    }
}
