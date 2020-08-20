using BlockbusterApp.src.Domain.CategoryAggregate.Event;
using BlockbusterApp.src.Shared.Domain;
using System;
using System.Collections.Generic;

namespace BlockbusterApp.src.Domain.CategoryAggregate
{
    public class Category : AggregateRoot
    {

        public CategoryId id { get; }
        public CategoryName name { get; }
        public CategoryCreatedAt createdAt { get; }
        public CategoryUpdatedAt updatedAt { get; }

        private Category(
            CategoryId id,
            CategoryName name, 
            CategoryCreatedAt createdAt,
            CategoryUpdatedAt updatedAt)
        {
            this.id = id;
            this.name = name;
            this.createdAt = createdAt;
            this.updatedAt = updatedAt;
        }

        public static Category Create(CategoryId id, CategoryName name)
        {
            CategoryCreatedAt createdAt = new CategoryCreatedAt(DateTime.Now);
            CategoryUpdatedAt updatedAt = new CategoryUpdatedAt(DateTime.Now);

            Category category = new Category(id, name, createdAt,updatedAt);

            category.Record(new CategoryCreatedEvent(category.id.GetValue(),
                new Dictionary<string, string>()
                {
                    ["id"] = category.id.GetValue(),
                    ["name"] = category.name.GetValue(),
                    ["created_at"] = category.createdAt.GetValue().ToString(),
                    ["updated_at"] = category.updatedAt.GetValue().ToString()
                }
            ));

            return category;
        }

    }
}
