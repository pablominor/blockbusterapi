﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Shared.Application.Bus.UseCase.Response
{
    public interface ResponseConverter
    {
        IResponse Convert(dynamic item);

    }
}
