using BlockbusterApp.src.Domain.CategoryAggregate;
using BlockbusterApp.src.Shared.Domain.Exception;
using NUnit.Framework;

namespace UnitTest.Domain.CategoryAggregate
{
    [TestFixture]
    public class CategoryIdTest
    {

        [Test]
        public void ItShouldThrowExceptionFromEmpty()
        {
            string invalidEmptyId = "";

            var Exception = Assert.Throws<InvalidAttributeException>(() => new CategoryId(invalidEmptyId));

            Assert.Pass(Exception.Message, InvalidAttributeException.FromEmpty("UUID"));
            Assert.IsInstanceOf<InvalidUUIDException>(Exception);
        }

        [Test]
        public void ItShouldThrowExceptionFromInvalidFormat()
        {
            string invalidId = "123456789";

            var Exception = Assert.Throws<InvalidAttributeException>(() => new CategoryId(invalidId));

            Assert.Pass(Exception.Message, InvalidAttributeException.FromValue("UUID", invalidId));
            Assert.IsInstanceOf<InvalidUUIDException>(Exception);
        }

        [Test]
        public void ItShouldCreateNewCategoryId()
        {
            string id = "a742aea9-1923-45bd-903e-b0210436d6c2";

            CategoryId categoryId = new CategoryId(id);

            Assert.IsNotNull(categoryId);
            Assert.AreEqual(categoryId.GetValue(), id);
        }

        [Test]
        public void ItShouldReturnTrueWhenTwoCategoryIdAreEqual()
        {
            string id = "a742aea9-1923-45bd-903e-b0210436d6c2";

            CategoryId categoryId1 = new CategoryId(id);
            CategoryId categoryId2 = new CategoryId(id);

            Assert.IsTrue(categoryId1.Equals(categoryId2));
        }

    }
}
