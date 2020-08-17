using BlockbusterApp.src.Domain.UserAggregate.Service;
using BlockbusterApp.src.Infraestructure.Service.Token;
using BlockbusterApp.src.Shared.Infraestructure.Bus.UseCase;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using UnitTest.Application.UseCase.User.FindById;

namespace UnitTest.Application.UseCase.Token
{
    public class TokenAdapterStub
    {

        public static Mock<TokenAdapter> ByDefault()
        {
            Mock<TokenFacade> tokenFacade = getTokenFacade();
            Mock<TokenTranslator> tokenTranslator = new Mock<TokenTranslator>();
            Mock<TokenAdapter> tokenAdapter = new Mock<TokenAdapter>(tokenFacade.Object, tokenTranslator.Object);
            return tokenAdapter;
        }

        private static Mock<TokenFacade> getTokenFacade()
        {
            Mock<IUseCaseBus> useCaseBus = new Mock<IUseCaseBus>();
            Mock<UserFinder> userFinder = UserFinderStub.ByDefault();
            Mock<TokenFacade> tokenFacade = new Mock<TokenFacade>(useCaseBus.Object, userFinder.Object);
            return tokenFacade;
        }
    }
}
