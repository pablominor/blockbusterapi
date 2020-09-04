using BlockbusterApp.src.Application.UseCase.Category.Response;
using BlockbusterApp.src.Domain.CategoryAggregate;
using BlockbusterApp.src.Domain.CategoryAggregate.Service;
using BlockbusterApp.src.Shared.Application.Bus.UseCase;

namespace BlockbusterApp.src.Application.UseCase.Category.FindByName
{

    public class FindCategoryByNameUseCase : IUseCase
    {
        private CategoryFinder categoryFinder;
        private CategoryResponseConverter converter;

        public FindCategoryByNameUseCase(
            CategoryFinder categoryFinder,
            CategoryResponseConverter converter)
        {
            this.categoryFinder = categoryFinder;
            this.converter = converter;
        }

        public IResponse Execute(IRequest req)
        {
            FindCategoryByNameRequest request = req as FindCategoryByNameRequest;

            CategoryName categoryName = new CategoryName(request.Name);

            var category = categoryFinder.FindOneByName(categoryName);

            return this.converter.Convert(category);
        }
    }
}
