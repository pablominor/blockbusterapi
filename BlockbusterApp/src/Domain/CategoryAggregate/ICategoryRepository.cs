﻿namespace BlockbusterApp.src.Domain.CategoryAggregate
{
    public interface ICategoryRepository
    {
        void Add(Category category);
        Category FindById(CategoryId id);
        Category FindByName(CategoryName name);
    }
}