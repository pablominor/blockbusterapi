using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using BlockbusterApp.src.Shared.Application.Bus.UseCase.Response;

namespace BlockbusterApp.src.Application.UseCase.Category.Response
{
    public class CategoryResponseConverter : ResponseConverter
    {
        public CategoryResponseConverter() { }

        public virtual IResponse Convert(dynamic item)
        {
            Domain.CategoryAggregate.Category category = item as Domain.CategoryAggregate.Category;

            return new CategoryResponse()
            {
                Id = category.id.GetValue(),
                Name = category.name.GetValue()
            };

        }
    }
}
