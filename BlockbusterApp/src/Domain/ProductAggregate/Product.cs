using BlockbusterApp.src.Domain.ProductAggregate.Event;
using BlockbusterApp.src.Shared.Domain;
using System;
using System.Collections.Generic;

namespace BlockbusterApp.src.Domain.ProductAggregate 
{
    public class Product : AggregateRoot
    {

        public ProductId id { get; }
        public ProductName name { get; protected set;}
        public ProductDescription description { get; protected set; }
        public ProductPrice price { get; protected set; }
        public ProductCategoryId categoryId { get; protected set; }
        public ProductCreatedAt createdAt { get; }
        public ProductUpdatedAt updatedAt { get; protected set; }

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

        public void Update(ProductName name, ProductDescription description, ProductPrice price,ProductCategoryId categoryId)
        {
            UpdateProductName(name);
            UpdateProductDescription(description);
            UpdateProductPrice(price);
            UpdateProductCategoryId(categoryId);
        }

        private void UpdateProductName(ProductName name)
        {
            if (!name.Equals(this.name))
            {
                this.name = name;
                UpdateProductUpdatedAt();
            }
        }

        private void UpdateProductDescription(ProductDescription description)
        {
            if (!description.Equals(this.description))
            {
                this.description = description;
                UpdateProductUpdatedAt();
            }
        }

        private void UpdateProductPrice(ProductPrice price)
        {
            if (!price.Equals(this.price))
            {
                this.price = price;
                UpdateProductUpdatedAt();
            }
        }

        private void UpdateProductCategoryId(ProductCategoryId categoryId)
        {
            if (!categoryId.Equals(this.categoryId))
            {
                this.categoryId = categoryId;
                UpdateProductUpdatedAt();
            }
        }

        private void UpdateProductUpdatedAt()
        {
            this.updatedAt = new ProductUpdatedAt(DateTime.Now);
        }
    }
}
