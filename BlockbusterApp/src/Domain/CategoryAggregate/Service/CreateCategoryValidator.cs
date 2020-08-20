using BlockbusterApp.src.Domain.CategoryAggregate.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Domain.CategoryAggregate.Service
{
    public class CreateCategoryValidator
    {

        private ICategoryRepository categoryRepository;
        public CreateCategoryValidator(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public virtual void Validate(CategoryId id,CategoryName name)
        {
            var category = this.categoryRepository.FindById(id);
            if (category != null)
            {
                throw CategoryFoundException.FromId(id);
            }
            category = this.categoryRepository.FindByName(name);
            if (category != null)
            {
                throw CategoryFoundException.FromName(name);
            }
        }

    }
}
