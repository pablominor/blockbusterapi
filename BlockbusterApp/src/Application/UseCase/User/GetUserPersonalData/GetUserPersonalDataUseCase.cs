using BlockbusterApp.src.Application.UseCase.Exception.User;
using BlockbusterApp.src.Domain.UserAggregate;
using BlockbusterApp.src.Shared.Application.Bus.UseCase;

namespace BlockbusterApp.src.Application.UseCase.User.GetUserPersonalData
{
    public class GetUserPersonalDataUseCase : IUseCase
    {
        private IUserRepository userRepository;
        private GetUserPersonalDataConverter converter;

        public GetUserPersonalDataUseCase(IUserRepository userRepository, GetUserPersonalDataConverter converter)
        {
            this.userRepository = userRepository;
            this.converter = converter;
        }

        public IResponse Execute(IRequest req)
        {
            GetUserPersonalDataRequest request = req as GetUserPersonalDataRequest;

            UserId userId = new UserId(request.Id);

            var user = this.userRepository.FindUserById(userId);

            if (user is null)
            {
                throw UserNotFoundException.FromId(userId);
            }

            return this.converter.Convert(user);
        }
    }
}
