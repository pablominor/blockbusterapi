using BlockbusterApp.src.Domain.FilmAggregate.Event;
using BlockbusterApp.src.Shared.Domain;
using System;
using System.Collections.Generic;

namespace BlockbusterApp.src.Domain.FilmAggregate 
{
    public class Film : AggregateRoot
    {

        public FilmId id { get; }
        public FilmName name { get; }
        public FilmDescription description { get; }
        public FilmPrice price { get; }
        public FilmCategoryId categoryId { get; }
        public FilmCreatedAt createdAt { get; }
        public FilmUpdatedAt updatedAt { get; }

        private Film(
            FilmId id, 
            FilmName name, 
            FilmDescription description, 
            FilmPrice price, 
            FilmCategoryId categoryId, 
            FilmCreatedAt createdAt, 
            FilmUpdatedAt updatedAt)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.price = price;
            this.categoryId = categoryId;
            this.createdAt = createdAt;
            this.updatedAt = updatedAt;
        }

        public static Film Create(
            FilmId id,
            FilmName name,
            FilmDescription description,
            FilmPrice price,
            FilmCategoryId categoryId)
        {

            FilmCreatedAt createdAt = new FilmCreatedAt(DateTime.Now);
            FilmUpdatedAt updatedAt = new FilmUpdatedAt(DateTime.Now);

            Film film = new Film(id, name,description,price,categoryId, createdAt, updatedAt);

            film.Record(new FilmCreatedEvent(film.id.GetValue(),
                new Dictionary<string, string>()
                {
                    ["id"] = film.id.GetValue(),
                    ["name"] = film.name.GetValue(),
                    ["description"] = film.description.GetValue(),
                    ["price"] = film.price.GetValue().ToString(),
                    ["category_id"] = film.categoryId.GetValue(),
                    ["created_at"] = film.createdAt.GetValue().ToString(),
                    ["updated_at"] = film.updatedAt.GetValue().ToString()
                }
            ));

            return film;

        }
    }
}
