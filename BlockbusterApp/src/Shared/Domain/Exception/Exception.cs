﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Shared.Domain.Exception
{
    public class Exception : System.Exception
    {
        public Exception(string message) : base(message) { }
    }
}