﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Domain.UserAggregate
{
    public interface IUserAuthorization
    {
        void AuthorizeAsOwner(UserId id);       
    }
}
