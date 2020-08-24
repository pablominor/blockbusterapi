using BlockbusterApp.src.Domain.CategoryAggregate.Exception;

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
            ItShouldNotExistsCategoryWithIdOrName(id, name);
        }

        private void ItShouldNotExistsCategoryWithIdOrName(CategoryId id, CategoryName name)
        {
            Domain.CategoryAggregate.Category category = this.categoryRepository.FindByIdOrName(id,name);
            if (category != null && category.id.Equals(id))
            {
                throw CategoryFoundException.FromId(id);
            }
            if (category != null && category.name.Equals(name))
            {
                throw CategoryFoundException.FromName(name);
            }
        }

    }
}
