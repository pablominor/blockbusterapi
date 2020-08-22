using BlockbusterApp.src.Domain.UserAggregate;
using BlockbusterApp.src.Domain.UserAggregate.Service;
using BlockbusterApp.src.Infraestructure.Service.Hashing;
using BlockbusterApp.src.Shared.Application.Bus.UseCase;

namespace BlockbusterApp.src.Application.UseCase.User.Update
{
    public class UpdateUserUseCase : IUseCase
    {
        private UserFinder userFinder;
        private IUserRepository userRepository;
        private EmptyResponseConverter converter;
        private IHashing hashing;

        public UpdateUserUseCase(
            UserFinder userFinder,
            IUserRepository userRepository,
            EmptyResponseConverter converter,
            IHashing hashing)
        {
            this.userFinder = userFinder;
            this.userRepository = userRepository;
            this.converter = converter;
            this.hashing = hashing;
        }


        public IResponse Execute(IRequest req)
        {
            UpdateUserRequest request = req as UpdateUserRequest;

            UserId userId = UserValueObjectsFactory.CreateUserId(request.Id);
            Domain.UserAggregate.User user = this.userFinder.FindOneById(userId);

            UserHashedPassword userHashedPassword = this.hashing.Hash(request.Password);
            UserFirstName userFirstName = UserValueObjectsFactory.CreateUserFirstName(request.FirstName);
            UserLastName userLastName = UserValueObjectsFactory.CreateUserLastName(request.LastName);

            user.Update(userHashedPassword, userFirstName, userLastName);

            this.userRepository.Update(user);

            return this.converter.Convert();
        }
    }
}
