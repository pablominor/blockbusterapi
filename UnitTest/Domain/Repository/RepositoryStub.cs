using BlockbusterApp.src.Domain.CountryAggregate;
using BlockbusterApp.src.Domain.TokenAggregate;
using BlockbusterApp.src.Domain.UserAggregate;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTest.Domain.Repository
{
    public class RepositoryStub
    {
        public static Mock<IUserRepository> CreateUserRepository()
        {
            return new Mock<IUserRepository>();
        }

        public static Mock<ITokenRepository> CreateTokenRepository()
        {
            return new Mock<ITokenRepository>();
        }

        public static Mock<ICountryRepository> CreateCountryRepository()
        {
            return new Mock<ICountryRepository>();
        }

    }
}
