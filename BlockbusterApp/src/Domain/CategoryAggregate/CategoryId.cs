using BlockbusterApp.src.Shared.Domain;

namespace BlockbusterApp.src.Domain.CategoryAggregate
{  
    public class CategoryId : UUID
    {
        public CategoryId(string value) : base(value)
        {

        }
    }
}
