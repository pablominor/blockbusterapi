using BlockbusterApp.src.Application.UseCase.User.FindByEmalAndPassword;
using BlockbusterApp.src.Application.UseCase.User.FindById;
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

        public Domain.UserAggregate.User FindUserFromEmailAndPassword(string email,string password)
        {
            IResponse res = this.useCaseBus.Dispatch(new FindUserByEmailAndPasswordRequest(email, password));
            UserResponse response = res as UserResponse;
            return response.User;                        
        }

        public Domain.UserAggregate.User FindUserFromId(string id)
        {
            UserId userId = new UserId(id);
            return userFinder.ById(userId);
        }
    }
}
