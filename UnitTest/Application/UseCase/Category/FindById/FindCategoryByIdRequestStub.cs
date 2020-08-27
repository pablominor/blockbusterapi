using BlockbusterApp.src.Application.UseCase.Category.FindById;
using UnitTest.Domain.CategoryAggregate.Stub;

namespace UnitTest.Application.UseCase.Category.FindById
{
    public class FindCategoryByIdRequestStub
    {
        public static FindCategoryByIdRequest ByDefault()
        {
            return new FindCategoryByIdRequest(CategoryIdStub.ByDefault().GetValue());
        }
    }
}
