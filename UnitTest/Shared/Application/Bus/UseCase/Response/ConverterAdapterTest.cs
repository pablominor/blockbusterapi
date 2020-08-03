using BlockbusterApp.src.Application.UseCase.User.FindById;
using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using BlockbusterApp.src.Shared.Application.Bus.UseCase.Response;
using NUnit.Framework;
using System.Collections.Generic;
using UnitTest.Stub.UserAggregate;

namespace UnitTest.Shared.Application.Bus.UseCase.Response
{
    [TestFixture]
    public class ConverterAdapterTest
    {

        private Dictionary<string, Converter> converters;

        [SetUp]
        public void Init()
        {
            this.converters.Add("FindUserConverter", new FindUserConverter());
        }

        [TestCase("FindUserConverter", "FindUserResponse")]
        public void ItShouldConvertDynamicObjectsToResponseList(string converterName)
        {
            Converter converter = getConverter(converterName);
            
        }


        private Converter getConverter(string converterName)
        {
            return this.converters[converterName];
        }

    }
}
