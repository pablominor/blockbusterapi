using BlockbusterApp.src.Shared.Application.Bus.UseCase;

namespace BlockbusterApp.src.Application.UseCase.Category.FindByName
{

    public class FindCategoryByNameRequest : IRequest
    {

        public FindCategoryByNameRequest(string Name)
        {
            this.Name = Name;            
        }

        public string Name { get; }
    }
}
