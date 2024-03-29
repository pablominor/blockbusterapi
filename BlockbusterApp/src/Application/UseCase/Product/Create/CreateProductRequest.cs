﻿using BlockbusterApp.src.Shared.Application.Bus.UseCase;

namespace BlockbusterApp.src.Application.UseCase.Product.Create
{
    public class CreateProductRequest : IRequest
    {
        public CreateProductRequest(string Id, string Name, string Description, decimal Price, string CategoryId)
        {
            this.Id = Id;
            this.Name = Name;
            this.Description = Description;
            this.Price = Price;
            this.CategoryId = CategoryId;
        }

        public string Id { get; }
        public string Name { get; }
        public string Description { get; }
        public decimal Price { get; }
        public string CategoryId { get; }
    }
}
