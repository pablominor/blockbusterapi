using BlockbusterApp.src.Domain.UserAggregate;
using BlockbusterApp.src.Domain.UserAggregate.Service;
using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using BlockbusterApp.src.Shared.Infraestructure.Security.Authentication.JWT;

namespace BlockbusterApp.src.Application.UseCase.User.FindById
{
    public class FindUserByIdUseCase : IUseCase
    {
        private FindUserResponseConverter converter;
        private UserFinder userFinder;
        private IUserProvider userProvider;

        public FindUserByIdUseCase(FindUserResponseConverter converter, UserFinder userFinder, IUserProvider userProvider)
        {
            this.converter = converter;
            this.userFinder = userFinder;
            this.userProvider = userProvider;
        }

        public IResponse Execute(IRequest req)
        {            
            UserId userId = new UserId(userProvider.GetUser().userId);            

            var user = userFinder.ById(userId);

            return this.converter.Convert(user);
        }
    }
}
