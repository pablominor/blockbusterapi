using BlockbusterApp.src.Domain.ProductAggregate;
using BlockbusterApp.src.Shared.Domain.Exception;
using NUnit.Framework;

namespace UnitTest.Domain.ProductAggregate
{
    [TestFixture]
    public class ProductCategoryIdTest
    {
        [Test]
        public void ItShouldThrowExceptionFromEmpty()
        {
            string invalidEmptyId = "";

            var Exception = Assert.Throws<InvalidAttributeException>(() => new ProductCategoryId(invalidEmptyId));

            Assert.Pass(Exception.Message, InvalidAttributeException.FromEmpty("UUID"));
            Assert.IsInstanceOf<InvalidUUIDException>(Exception);
        }

        [Test]
        public void ItShouldThrowExceptionFromInvalidFormat()
        {
            string invalidId = "123456789";

            var Exception = Assert.Throws<InvalidAttributeException>(() => new ProductCategoryId(invalidId));

            Assert.Pass(Exception.Message, InvalidAttributeException.FromValue("UUID", invalidId));
            Assert.IsInstanceOf<InvalidUUIDException>(Exception);
        }

        [Test]
        public void ItShouldCreateNewProductCategoryId()
        {
            string id = "a742aea9-1923-45bd-903e-b0210436d6c2";

            ProductCategoryId productCategoryId = new ProductCategoryId(id);

            Assert.IsNotNull(productCategoryId);
            Assert.AreEqual(productCategoryId.GetValue(), id);
        }

        [Test]
        public void ItShouldReturnTrueWhenTwoProductCategoryIdAreEqual()
        {
            string id = "a742aea9-1923-45bd-903e-b0210436d6c2";

            ProductCategoryId productCategoryId1 = new ProductCategoryId(id);
            ProductCategoryId productCategoryId2 = new ProductCategoryId(id);

            Assert.IsTrue(productCategoryId1.Equals(productCategoryId2));
        }
    }
}
