using BlockbusterApp.src.Domain.CategoryAggregate;
using BlockbusterApp.src.Domain.CategoryAggregate.Service;
using BlockbusterApp.src.Shared.Application.Bus.UseCase;

namespace BlockbusterApp.src.Application.UseCase.Category.Create
{
    public class CreateCategoryUseCase : IUseCase
    {
        private ICategoryFactory categoryFactory;
        private ICategoryRepository categoryRepository;
        private EmptyResponseConverter converter;
        private CreateCategoryValidator validator;

        public CreateCategoryUseCase(
            ICategoryFactory categoryFactory, 
            ICategoryRepository categoryRepository, 
            EmptyResponseConverter converter,
            CreateCategoryValidator validator)
        {
            this.categoryFactory = categoryFactory;
            this.categoryRepository = categoryRepository;
            this.converter = converter;
            this.validator = validator;
        }

        public IResponse Execute(IRequest req)
        {
            CreateCategoryRequest request = req as CreateCategoryRequest;
            
            Domain.CategoryAggregate.Category category = categoryFactory.Create(request.Id,request.Name);

            this.validator.Validate(category.id,category.name);
           
            this.categoryRepository.Add(category);
            
            return this.converter.Convert();
        }
    }
}
