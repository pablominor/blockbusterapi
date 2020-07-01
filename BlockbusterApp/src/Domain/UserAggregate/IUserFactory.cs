using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Domain.UserAggregate
{
    public interface IUserFactory
    {
        User Create(
            string id,
            string email,
            string password,
            string repeatPassword,
            string firstName,
            string lastName,
            string role);

    }
}
