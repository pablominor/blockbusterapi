using BlockbusterApp.src.Application.UseCase.User.Response;
using BlockbusterApp.src.Domain.TokenAggregate;
using BlockbusterApp.src.Domain.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Infraestructure.Service.Token
{
    public class TokenAdapter
    {
        private TokenFacade tokenFacade;
        private TokenTranslator tokenTranslator;

        public TokenAdapter(TokenFacade tokenFacade,TokenTranslator tokenTranslator)
        {
            this.tokenFacade = tokenFacade;
            this.tokenTranslator = tokenTranslator;
        }

        public virtual Dictionary<string,string> FindPayloadFromEmailAndPassword(string email, string password)
        {
            var user = this.tokenFacade.FindUserFromEmailAndPassword(email, password);
            return this.tokenTranslator.FromRepresentationToPayLoad(user);
        }

        public virtual Dictionary<string, string> FindPayloadFromUserId(string id)
        {
            var user = this.tokenFacade.FindUserFromId(id);
            return this.tokenTranslator.FromRepresentationToPayLoad(user);
        }

    }
}
