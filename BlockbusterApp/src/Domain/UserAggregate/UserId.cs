﻿using BlockbusterApp.src.Shared.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Domain.UserAggregate
{
    public class UserId : UUID
    {
        public UserId(string value) : base(value)
        {

        }
    }
}
