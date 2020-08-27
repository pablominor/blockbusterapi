using BlockbusterApp.src.Application.UseCase.Category.Create;
using UnitTest.Domain.CategoryAggregate.Stub;

namespace UnitTest.Application.UseCase.Category.Create
{   
    public class CreateCategoryRequestStub
    {
        public static CreateCategoryRequest ByDefault()
        {
            return new CreateCategoryRequest(
                CategoryIdStub.ByDefault().GetValue(),
                CategoryNameStub.ByDefault().GetValue());
        }
    }
}
