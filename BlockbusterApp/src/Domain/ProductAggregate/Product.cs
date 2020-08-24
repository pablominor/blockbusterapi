using BlockbusterApp.src.Domain.ProductAggregate.Event;
using BlockbusterApp.src.Shared.Domain;
using System;
using System.Collections.Generic;

namespace BlockbusterApp.src.Domain.ProductAggregate 
{
    public class Product : AggregateRoot
    {

        public ProductId id { get; }
        public ProductName name { get; }
        public ProductDescription description { get; }
        public ProductPrice price { get; }
        public ProductCategoryId categoryId { get; }
        public ProductCreatedAt createdAt { get; }
        public ProductUpdatedAt updatedAt { get; }

        private Product(
            ProductId id, 
            ProductName name, 
            ProductDescription description, 
            ProductPrice price, 
            ProductCategoryId categoryId, 
            ProductCreatedAt createdAt, 
            ProductUpdatedAt updatedAt)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.price = price;
            this.categoryId = categoryId;
            this.createdAt = createdAt;
            this.updatedAt = updatedAt;
        }

        public static Product Create(
            ProductId id,
            ProductName name,
            ProductDescription description,
            ProductPrice price,
            ProductCategoryId categoryId)
        {

            ProductCreatedAt createdAt = new ProductCreatedAt(DateTime.Now);
            ProductUpdatedAt updatedAt = new ProductUpdatedAt(DateTime.Now);

            Product product = new Product(id, name,description,price,categoryId, createdAt, updatedAt);

            product.Record(new ProductCreatedEvent(product.id.GetValue(),
                new Dictionary<string, string>()
                {
                    ["id"] = product.id.GetValue(),
                    ["name"] = product.name.GetValue(),
                    ["description"] = product.description.GetValue(),
                    ["price"] = product.price.GetValue().ToString(),
                    ["category_id"] = product.categoryId.GetValue(),
                    ["created_at"] = product.createdAt.GetValue().ToString(),
                    ["updated_at"] = product.updatedAt.GetValue().ToString()
                }
            ));

            return product;

        }
    }
}
