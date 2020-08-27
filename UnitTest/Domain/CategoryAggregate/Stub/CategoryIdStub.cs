using BlockbusterApp.src.Domain.CategoryAggregate;

namespace UnitTest.Domain.CategoryAggregate.Stub
{
    public class CategoryIdStub
    {

        public static CategoryId Create(string id)
        {
            return new CategoryId(id);
        }

        public static CategoryId ByDefault()
        {
            return new CategoryId("3debbe23-f331-40b9-95dc-43148c705fc7");
        }

    }
}
