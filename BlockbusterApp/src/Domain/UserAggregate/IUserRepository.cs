using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Domain.UserAggregate
{
    public interface IUserRepository
    {
        void Save(User user);
        User FindOneByEmail(UserEmail userEmail);
    }
}
