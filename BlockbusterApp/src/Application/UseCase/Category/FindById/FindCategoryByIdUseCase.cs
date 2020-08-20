using BlockbusterApp.src.Application.UseCase.Category.Response;
using BlockbusterApp.src.Domain.CategoryAggregate;
using BlockbusterApp.src.Domain.CategoryAggregate.Service;
using BlockbusterApp.src.Shared.Application.Bus.UseCase;

namespace BlockbusterApp.src.Application.UseCase.Category.FindById
{
    public class FindCategoryByIdUseCase : IUseCase
    {
        private CategoryResponseConverter converter;
        private CategoryFinder categoryFinder;

        public FindCategoryByIdUseCase(CategoryResponseConverter converter, CategoryFinder categoryFinder)
        {
            this.converter = converter;
            this.categoryFinder = categoryFinder;
        }

        public IResponse Execute(IRequest req)
        {
            FindCategoryByIdRequest request = req as FindCategoryByIdRequest;

            CategoryId categoryId = new CategoryId(request.Id);

            var category = categoryFinder.ById(categoryId);

            return this.converter.Convert(category);
        }
    }
}
