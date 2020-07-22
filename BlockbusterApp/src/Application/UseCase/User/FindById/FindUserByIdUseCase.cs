using BlockbusterApp.src.Domain.UserAggregate;
using BlockbusterApp.src.Domain.UserAggregate.Service;
using BlockbusterApp.src.Shared.Application.Bus.UseCase;

namespace BlockbusterApp.src.Application.UseCase.User.FindById
{
    public class FindUserByIdUseCase : IUseCase
    {
        private FindUserConverter converter;
        private UserFinder userFinder;

        public FindUserByIdUseCase(FindUserConverter converter, UserFinder userFinder)
        {
            this.converter = converter;
            this.userFinder = userFinder;
        }

        public IResponse Execute(IRequest req)
        {
            FindUserByIdRequest request = req as FindUserByIdRequest;

            UserId userId = new UserId(request.Id);

            var user = userFinder.ById(userId);

            return this.converter.Convert(user);
        }
    }
}
