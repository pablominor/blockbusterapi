using BlockbusterApp.src.Shared.Application.Bus.UseCase;

namespace BlockbusterApp.src.Application.UseCase.Category.FindById
{
    public class FindCategoryByIdRequest : IRequest
    {

        public FindCategoryByIdRequest(string Id)
        {
            this.Id = Id;
        }

        public string Id { get; }
    }
}
