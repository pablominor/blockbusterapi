using BlockbusterApp.src.Domain.UserAggregate;
using BlockbusterApp.src.Domain.UserAggregate.Service;
using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using BlockbusterApp.src.Shared.Domain.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Application.UseCase.User.SignUP
{
    public class SignUpUserUseCase : IUseCase
    {
        private IUserFactory _userFactory;
        private SignUpUserValidator _userValidator;
        private IUserRepository _userRepository;
        private UserConverter _userConverter;
        private IEventProvider _eventProvider;

        public SignUpUserUseCase(
            IUserFactory userFactory, 
            SignUpUserValidator userValidator, 
            IUserRepository userRepository, 
            UserConverter userConverter,
            IEventProvider eventProvider)
        {
            _userFactory = userFactory;
            _userValidator = userValidator;
            _userRepository = userRepository;
            _userConverter = userConverter;
            _eventProvider = eventProvider;
        }

        public IResponse Execute(IRequest req)
        {
            SignUpUserRequest request = req as SignUpUserRequest;

            Domain.UserAggregate.User user = _userFactory.Create(
                request.Id, 
                request.Email, 
                request.Password, 
                request.RepeatPassword, 
                request.FirstName, 
                request.LastName, 
                request.Role);

            _eventProvider.RecordEvents(user.ReleaseEvents());

            _userValidator.Validate(user.userEmail);

            _userRepository.Add(user);

            return _userConverter.Convert();

        }

    }
}
