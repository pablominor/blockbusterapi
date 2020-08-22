using BlockbusterApp.src.Application.UseCase.User.Response;
using BlockbusterApp.src.Domain.UserAggregate;
using BlockbusterApp.src.Domain.UserAggregate.Service;
using BlockbusterApp.src.Shared.Application.Bus.UseCase;

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

            var user = userFinder.FindOneById(userId);

            return this.converter.Convert(user);
        }
    }
}
