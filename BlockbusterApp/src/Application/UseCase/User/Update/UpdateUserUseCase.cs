using BlockbusterApp.src.Domain.UserAggregate;
using BlockbusterApp.src.Shared.Application.Bus.UseCase;

namespace BlockbusterApp.src.Application.UseCase.User.Update
{
    public class UpdateUserUseCase : IUseCase
    {
        private IUserUpdater userUpdater;
        private IUserRepository userRepository;
        private EmptyResponseConverter converter;

        public UpdateUserUseCase(
            IUserUpdater userUpdater,
            IUserRepository userRepository,
            EmptyResponseConverter converter)
        {
            this.userUpdater = userUpdater;
            this.userRepository = userRepository;
            this.converter = converter;
        }


        public IResponse Execute(IRequest req)
        {
            UpdateUserRequest request = req as UpdateUserRequest;

            Domain.UserAggregate.User user = this.userUpdater.Update(
                request.Id,
                request.Password,
                request.FirstName,
                request.LastName);
            
            this.userRepository.Update(user);
            
            return this.converter.Convert();
        }
    }
}
