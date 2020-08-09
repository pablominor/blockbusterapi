using BlockbusterApp.src.Application.UseCase.User.FindById;
using BlockbusterApp.src.Domain.UserAggregate;
using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using System.Collections.ObjectModel;

namespace BlockbusterApp.src.Application.UseCase.User.FindByFilter
{
    public class GetUsersUseCase : IUseCase
    {
        private IUserRepository userRepository;
        private GetUsersConverter converter;

        public GetUsersUseCase(IUserRepository userRepository, GetUsersConverter converter)
        {
            this.userRepository = userRepository;
            this.converter = converter;
        }

        public IResponse Execute(IRequest req)
        {
            GetUsersRequest request = req as GetUsersRequest;

            var users = this.userRepository.GetUsers(request.Page());

            return this.converter.Convert(users);            
        }

    }
}
