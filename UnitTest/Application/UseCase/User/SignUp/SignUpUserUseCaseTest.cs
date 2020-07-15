﻿using BlockbusterApp.src.Application.UseCase.User.SignUP;
using BlockbusterApp.src.Domain.UserAggregate;
using BlockbusterApp.src.Domain.UserAggregate.Service;
using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using BlockbusterApp.src.Shared.Domain.Event;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Internal.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnitTest.Stub.Request;
using UnitTest.Stub.UserAggregate;

namespace UnitTest.Application.UseCase.User.SignUp
{
    [TestFixture]
    public class SignUpUserUseCaseTest
    {

        [Test]
        public void ItShouldCallCollaborators()
        {            
            SignUpUserRequest request = SignUpUserRequestStub.ByDefault();
            BlockbusterApp.src.Domain.UserAggregate.User user = UserStub.ByDefault();
            Mock<IUserFactory> userFactory = new Mock<IUserFactory>();
            userFactory.Setup(o => o.Create(
                request.Id,
                request.Email,
                request.Password,
                request.RepeatPassword,
                request.FirstName,
                request.LastName,
                request.Role
                ))
                .Returns(user);
            Mock<IEventProvider> eventProvider = new Mock<IEventProvider>();
            eventProvider.Setup(o => o.RecordEvents(It.IsAny<List<DomainEvent>>()));
            Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
            userRepository.Setup(o => o.Add(user));
            Mock<SignUpUserValidator> signUpUserValidator = new Mock<SignUpUserValidator>(userRepository.Object);
            Mock<UserConverter> userConverter = new Mock<UserConverter>();
            userConverter.Setup(o => o.Convert());

            SignUpUserUseCase useCase = new SignUpUserUseCase(
                userFactory.Object,
                signUpUserValidator.Object,
                userRepository.Object,
                userConverter.Object,
                eventProvider.Object
                );

            useCase.Execute(request);

            userFactory.VerifyAll();
            signUpUserValidator.VerifyAll();
            userRepository.VerifyAll();
            userConverter.VerifyAll();
            eventProvider.VerifyAll();
        }
    }
}