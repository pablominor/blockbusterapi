using BlockbusterApp.src.Application.UseCase.User.FindByEmalAndPassword;
using BlockbusterApp.src.Domain.UserAggregate;
using BlockbusterApp.src.Domain.UserAggregate.Service;
using BlockbusterApp.src.Infraestructure.Service.Hashing;
using BlockbusterApp.src.Shared.Application.Bus.UseCase;

namespace BlockbusterApp.src.Application.UseCase.User.FindById
{
    public class FindUserByEmailAndPasswordUseCase : IUseCase
    {
        private UserFinder userFinder;
        private IHashing hashing;

        public FindUserByEmailAndPasswordUseCase(UserFinder userFinder, IHashing hashing)
        {
            this.userFinder = userFinder;
            this.hashing = hashing;
        }

        public IResponse Execute(IRequest req)
        {
            FindUserByEmailAndPasswordRequest request = req as FindUserByEmailAndPasswordRequest;

            UserEmail userEmail = new UserEmail(request.Email);
            UserHashedPassword userHashedPassword = this.hashing.Hash(request.Password);

            var user = userFinder.ByEmailAndPassword(userEmail,userHashedPassword);

            return new UserResponse(user);            
        }
    }
}
