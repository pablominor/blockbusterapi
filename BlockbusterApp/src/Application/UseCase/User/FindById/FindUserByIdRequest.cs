﻿using BlockbusterApp.src.Shared.Application.Bus.UseCase;

namespace BlockbusterApp.src.Application.UseCase.User.FindById
{
    public class FindUserByIdRequest : IRequest
    {
        public FindUserByIdRequest(string id)
        {
            this.id = id;
        }

        public string id { get; set; }
    }
}
