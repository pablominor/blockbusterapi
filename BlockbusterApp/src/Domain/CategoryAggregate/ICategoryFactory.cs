﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Domain.CategoryAggregate
{
    public interface ICategoryFactory
    {
        Category Create(string id, string name);
    }
}
