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

        public FindUserByIdUseCase(FindUserResponseConverter converter, UserFinder userFinder)
        {
            this.converter = converter;
            this.userFinder = userFinder;
        }

        public IResponse Execute(IRequest req)
        {            
            FindUserByIdRequest request = req as FindUserByIdRequest;

            UserId userId = new UserId(request.id);            

            var user = userFinder.ById(userId);

            return this.converter.Convert(user);
        }
    }
}
