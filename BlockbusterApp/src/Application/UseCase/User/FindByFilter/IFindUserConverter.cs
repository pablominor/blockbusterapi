using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using System.Collections.Generic;

namespace BlockbusterApp.src.Application.UseCase.User.FindByFilter
{
    public interface IFindUserConverter
    {
        IResponse Convert(IEnumerable<Domain.UserAggregate.User> users);

    }
}
