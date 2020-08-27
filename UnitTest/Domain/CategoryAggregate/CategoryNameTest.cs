using BlockbusterApp.src.Domain.CategoryAggregate;
using BlockbusterApp.src.Domain.CategoryAggregate.Exception;
using BlockbusterApp.src.Shared.Domain.Exception;
using NUnit.Framework;

namespace UnitTest.Domain.CategoryAggregate
{
    [TestFixture]
    public class CategoryNameTest
    {

        [Test]
        public void ItShouldThrowExceptionFromMaxLength()
        {
            string invalidName = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";

            var Exception = Assert.Throws<InvalidAttributeException>(() => new CategoryName(invalidName));

            Assert.Pass(Exception.Message, InvalidAttributeException.FromMaxLength("name", CategoryName.MAX_LENGTH));
            Assert.IsInstanceOf<InvalidCategoryAttributeException>(Exception);
        }

        [Test]
        public void ItShouldThrowExceptionFromMinLength()
        {
            string invalidName = "aa";

            var Exception = Assert.Throws<InvalidAttributeException>(() => new CategoryName(invalidName));

            Assert.Pass(Exception.Message, InvalidAttributeException.FromMinLength("name", CategoryName.MIN_LENGTH));
            Assert.IsInstanceOf<InvalidCategoryAttributeException>(Exception);
        }

        [Test]
        public void ItShouldCreateNewCategoryName()
        {
            string name = "Terminator";

            CategoryName categoryName = new CategoryName(name);

            Assert.IsNotNull(categoryName);
            Assert.AreEqual(categoryName.GetValue(), name);
        }

        [Test]
        public void ItShouldReturnTrueWhenTwoCategoryNameAreEqual()
        {
            string name = "Terminator";

            CategoryName categoryName1 = new CategoryName(name);
            CategoryName categoryName2 = new CategoryName(name);

            Assert.IsTrue(categoryName1.Equals(categoryName2));
        }

    }
}
