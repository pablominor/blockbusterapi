using BlockbusterApp.src.Application.UseCase.Country.FindByCode;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using UnitTest.Domain.CountryAggregate.Stub;

namespace UnitTest.Application.UseCase.Country.FindByCode
{
    [TestFixture]
    public class FindCountryByCodeRequestTest
    {

        [Test]
        public void ItShouldReturnSameNumberOfValuesWhenRequestIsCorrect()
        {
            FindCountryByCodeRequest request = new FindCountryByCodeRequest(
                CountryCodeStub.ByDefault().GetValue());

            Type type = typeof(FindCountryByCodeRequest);
            int numberOfFields = type.GetProperties().Length;

            Assert.AreEqual(numberOfFields,1);
            Assert.AreEqual(request.Code, CountryCodeStub.ByDefault().GetValue());            
        }

    }
}
