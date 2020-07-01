using BlockbusterApp.src.Domain.UserAggregate;
using BlockbusterApp.src.Domain.UserAggregate.Service;
using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Application.UseCase
{
    public class SignUpUserUseCase : IUseCase
    {
        private IUserFactory _userFactory;
        private SignUpUserValidator _userValidator;
        private IUserRepository _userRepository;
        private UserConverter _userConverter;

        public SignUpUserUseCase(
            IUserFactory userFactory, 
            SignUpUserValidator userValidator, 
            IUserRepository userRepository, 
            UserConverter userConverter)
        {
            _userFactory = userFactory;
            _userValidator = userValidator;
            _userRepository = userRepository;
            _userConverter = userConverter;
        }

        public IResponse Execute(IRequest req)
        {
            SignUpUserRequest request = req as SignUpUserRequest;

            User user = _userFactory.Create(
                request.Id, 
                request.Email, 
                request.Password, 
                request.RepeatPassword, 
                request.FirstName, 
                request.LastName, 
                request.Role);

            _userValidator.Validate(user.userEmail);

            _userRepository.Add(user);

            return _userConverter.Convert();

        }

    }
}
