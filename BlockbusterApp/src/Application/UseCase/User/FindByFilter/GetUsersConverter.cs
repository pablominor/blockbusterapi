using BlockbusterApp.src.Application.UseCase.User.FindById;
using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using System.Collections.Generic;

namespace BlockbusterApp.src.Application.UseCase.User.FindByFilter
{
    public class GetUsersConverter : IFindUserConverter
    {
        private FindUserConverter findUserConverter;

        public GetUsersConverter(FindUserConverter findUserConverter) {
            this.findUserConverter = findUserConverter;
        }

        public IResponse Convert(IEnumerable<Domain.UserAggregate.User> users) 
        {
            List<UserDTO> usersConverted = new List<UserDTO>();

            foreach(var user in users)
            {
                IResponse responseUser = this.findUserConverter.Convert(user);
                FindUserResponse res = responseUser as FindUserResponse;
                usersConverted.Add(res.User);
            }

            GetUsersResponse response = new GetUsersResponse
            {
                AllUsers = usersConverted
            };

            return response;
        }

    }
}
