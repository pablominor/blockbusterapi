﻿using BlockbusterApp.src.Domain.CategoryAggregate.Exception;

namespace BlockbusterApp.src.Domain.CategoryAggregate.Service
{
    public class CategoryFinder
    {
        private ICategoryRepository categoryRepository;

        public CategoryFinder(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public virtual Category FindOneById(CategoryId categoryId)
        {
            var category = this.categoryRepository.FindById(categoryId);
            if (category == null)
            {
                throw CategoryNotFoundException.FromId(categoryId);
            }
            return category;
        }

        public virtual Category FindOneByName(CategoryName categoryName)
        {
            var category = this.categoryRepository.FindByName(categoryName);
            if (category == null)
            {
                throw CategoryNotFoundException.FromName(categoryName);
            }
            return category;
        }
    }
}
