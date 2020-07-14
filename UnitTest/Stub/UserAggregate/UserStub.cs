using BlockbusterApp.src.Application.UseCase.User.SignUP;
using BlockbusterApp.src.Domain.UserAggregate;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net.Cache;
using System.Runtime.CompilerServices;
using System.Text;

namespace UnitTest.Stub.UserAggregate
{
    public class UserStub
    {

        public static User CreateFromRequest(SignUpUserRequest request)
        {
            return Create(
                UserIdStub.Crate(request.Id),
                UserEmailStub.Crate(request.Email),
                UserPasswordStub.Crate(request.Password),
                UserFirstNameStub.Crate(request.FirstName),
                UserLastNameStub.Crate(request.LastName),
                UserRoleStub.Create(request.Role)
            );
        }

        public static User WithRole(string role)
        {
            return Create(
                UserIdStub.ByDefault(),
                UserEmailStub.ByDefault(),
                UserPasswordStub.ByDefault(),
                UserFirstNameStub.ByDefault(),
                UserLastNameStub.ByDefault(),
                UserRoleStub.Create(role)
            );
        }

        public static User ByDefault()
        {
            return Create(
                UserIdStub.ByDefault(),
                UserEmailStub.ByDefault(),
                UserPasswordStub.ByDefault(),
                UserFirstNameStub.ByDefault(),
                UserLastNameStub.ByDefault(),
                UserRoleStub.CreateLikeUser()
            );
        }
       

        private static User Create(
            UserId Id,
            UserEmail Email,
            UserHashedPassword HashedPassword,
            UserFirstName FirstName,
            UserLastName LastName,
            UserRole Role)
        {
            return User.SignUp(
                Id, 
                Email, 
                HashedPassword, 
                FirstName, 
                LastName, 
                Role);
        }
    }
}
