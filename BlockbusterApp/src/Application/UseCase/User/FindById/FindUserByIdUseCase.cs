using BlockbusterApp.src.Domain.UserAggregate;
using BlockbusterApp.src.Domain.UserAggregate.Service;
using BlockbusterApp.src.Shared.Application.Bus.UseCase;

namespace BlockbusterApp.src.Application.UseCase.User.FindById
{
    public class FindUserByIdUseCase : IUseCase
    {
        private FindUserResponseConverter converter;
        private UserFinder userFinder;
        private IUserAuthorization userAuthorization;

        public FindUserByIdUseCase(FindUserResponseConverter converter, UserFinder userFinder, IUserAuthorization userAuthorization)
        {
            this.converter = converter;
            this.userFinder = userFinder;
            this.userAuthorization = userAuthorization;
        }

        public IResponse Execute(IRequest req)
        {
            FindUserByIdRequest request = req as FindUserByIdRequest;

            UserId userId = new UserId(request.Id);

            this.userAuthorization.AuthorizeAsOwner(userId);

            var user = userFinder.ById(userId);

            return this.converter.Convert(user);
        }
    }
}
