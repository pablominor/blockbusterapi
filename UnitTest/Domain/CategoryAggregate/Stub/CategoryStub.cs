using BlockbusterApp.src.Application.UseCase.Category.Create;
using BlockbusterApp.src.Domain.CategoryAggregate;

namespace UnitTest.Domain.CategoryAggregate.Stub
{
    public class CategoryStub
    {

        public static BlockbusterApp.src.Domain.CategoryAggregate.Category CreateFromRequest(CreateCategoryRequest request)
        {
            return Create(
                CategoryIdStub.Create(request.Id),
                CategoryNameStub.Create(request.Name)
            );
        }

        public static BlockbusterApp.src.Domain.CategoryAggregate.Category ByDefault()
        {
            return Create(
                CategoryIdStub.ByDefault(),
                CategoryNameStub.ByDefault()
            );
        }


        private static BlockbusterApp.src.Domain.CategoryAggregate.Category Create(
            CategoryId Id,
            CategoryName Name)
        {
            return BlockbusterApp.src.Domain.CategoryAggregate.Category.Create(
                Id,
                Name);
        }
    }
}
