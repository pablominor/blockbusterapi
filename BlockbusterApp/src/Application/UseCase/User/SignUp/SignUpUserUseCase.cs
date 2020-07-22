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
        private IUserFactory userFactory;
        private SignUpUserValidator userValidator;
        private IUserRepository userRepository;
        private EmptyResponseConverter emptyResponseConverter;
        private IEventProvider eventProvider;

        public SignUpUserUseCase(
            IUserFactory userFactory, 
            SignUpUserValidator userValidator, 
            IUserRepository userRepository,
            EmptyResponseConverter emptyResponseConverter,
            IEventProvider eventProvider)
        {
            this.userFactory = userFactory;
            this.userValidator = userValidator;
            this.userRepository = userRepository;
            this.emptyResponseConverter = emptyResponseConverter;
            this.eventProvider = eventProvider;
        }

        public IResponse Execute(IRequest req)
        {
            SignUpUserRequest request = req as SignUpUserRequest;

            Domain.UserAggregate.User user = this.userFactory.Create(
                request.Id, 
                request.Email, 
                request.Password, 
                request.RepeatPassword, 
                request.FirstName, 
                request.LastName, 
                request.Role,
                request.CountryCode);

            this.eventProvider.RecordEvents(user.ReleaseEvents());

            this.userValidator.Validate(user.userEmail);

            this.userRepository.Add(user);

            return this.emptyResponseConverter.Convert();

        }

    }
}
