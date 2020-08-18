using BlockbusterApp.src.Application.UseCase.User.FindByEmalAndPassword;
using BlockbusterApp.src.Application.UseCase.User.FindById;
using BlockbusterApp.src.Application.UseCase.User.Response;
using BlockbusterApp.src.Domain.TokenAggregate;
using BlockbusterApp.src.Domain.UserAggregate;
using BlockbusterApp.src.Domain.UserAggregate.Service;
using BlockbusterApp.src.Infraestructure.Service.Hashing;
using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using BlockbusterApp.src.Shared.Infraestructure.Bus.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Infraestructure.Service.Token
{
    public class TokenFacade
    {
        private IUseCaseBus useCaseBus;
        private UserFinder userFinder;

        public TokenFacade(IUseCaseBus useCaseBus, UserFinder userFinder)
        {
            this.useCaseBus = useCaseBus;
            this.userFinder = userFinder;
        }

        public object FindUserFromEmailAndPassword(string email,string password)
        {
            IResponse res = this.useCaseBus.Dispatch(new FindUserByEmailAndPasswordRequest(email, password));            
            return res;
        }

        public object FindUserFromId(string id)
        {
            IResponse res = this.useCaseBus.Dispatch(new FindUserByIdRequest(id));
            return res;
        }
    }
}
