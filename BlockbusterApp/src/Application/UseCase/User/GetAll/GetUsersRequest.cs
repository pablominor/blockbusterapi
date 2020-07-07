﻿using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Application.UseCase.User.GetAll
{
    public class GetUsersRequest : AbstractRequest
    {
        public GetUsersRequest(IQueryCollection query) : base(query) { }
    }
}
