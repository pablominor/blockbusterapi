using BlockbusterApp.src.Shared.Application.Bus.UseCase;

namespace BlockbusterApp.src.Application.UseCase.Category.Create
{
    public class CreateCategoryRequest : IRequest
    {
        public CreateCategoryRequest(string Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
        }

        public string Id { get; }
        public string Name { get; }
    }
}
