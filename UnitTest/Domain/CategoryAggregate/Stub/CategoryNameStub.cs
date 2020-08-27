using BlockbusterApp.src.Domain.CategoryAggregate;

namespace UnitTest.Domain.CategoryAggregate.Stub
{
    public class CategoryNameStub
    {
        public static CategoryName Create(string name)
        {
            return new CategoryName(name);
        }

        public static CategoryName ByDefault()
        {
            return new CategoryName("action");
        }
    }
}
