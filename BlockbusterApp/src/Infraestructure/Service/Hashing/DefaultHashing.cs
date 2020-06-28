using BlockbusterApp.src.Domain.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Infraestructure.Service.Hashing
{
    public class DefaultHashing : IHashing
    {
        public UserHashedPassword Hash(string password)
        {
            var bytes = new UTF8Encoding().GetBytes(password);
            byte[] hashBytes;

            using(var algorithm = new SHA512Managed())
            {
                hashBytes = algorithm.ComputeHash(bytes);
            }

            string hash =  Convert.ToBase64String(hashBytes);
            return new UserHashedPassword(hash);
        }
    }
}
