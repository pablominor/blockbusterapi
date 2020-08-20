using BlockbusterApp.src.Domain.CategoryAggregate;

namespace BlockbusterApp.src.Infraestructure.Service.Category
{
    public class CategoryFactory : ICategoryFactory
    {
        public Domain.CategoryAggregate.Category Create(string id, string name)
        {
            CategoryId categoryId = new CategoryId(id);
            CategoryName categoryName = new CategoryName(name);

            return Domain.CategoryAggregate.Category.Create(categoryId, categoryName);
        }
    }
}
