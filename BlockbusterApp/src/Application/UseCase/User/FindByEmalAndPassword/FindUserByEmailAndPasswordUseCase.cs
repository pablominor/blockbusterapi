using BlockbusterApp.src.Application.UseCase.User.Response;
using BlockbusterApp.src.Domain.UserAggregate;
using BlockbusterApp.src.Domain.UserAggregate.Service;
using BlockbusterApp.src.Infraestructure.Service.Hashing;
using BlockbusterApp.src.Shared.Application.Bus.UseCase;

namespace BlockbusterApp.src.Application.UseCase.User.FindByEmalAndPassword
{
    public class FindUserByEmailAndPasswordUseCase : IUseCase
    {
        private UserFinder userFinder;
        private IHashing hashing;
        private FindUserResponseConverter converter;

        public FindUserByEmailAndPasswordUseCase(
            UserFinder userFinder, 
            IHashing hashing,
            FindUserResponseConverter converter)
        {
            this.userFinder = userFinder;
            this.hashing = hashing;
            this.converter = converter;
        }

        public IResponse Execute(IRequest req)
        {
            FindUserByEmailAndPasswordRequest request = req as FindUserByEmailAndPasswordRequest;

            UserEmail userEmail = new UserEmail(request.Email);
            UserHashedPassword userHashedPassword = this.hashing.Hash(request.Password);

            var user = userFinder.ByEmailAndPassword(userEmail,userHashedPassword);

            return this.converter.Convert(user); 
        }
    }
}
