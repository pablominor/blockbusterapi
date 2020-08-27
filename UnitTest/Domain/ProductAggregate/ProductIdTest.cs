using BlockbusterApp.src.Domain.ProductAggregate;
using BlockbusterApp.src.Shared.Domain.Exception;
using NUnit.Framework;

namespace UnitTest.Domain.ProductAggregate
{
    [TestFixture]
    public class ProductIdTest
    {
        [Test]
        public void ItShouldThrowExceptionFromEmpty()
        {
            string invalidEmptyId = "";

            var Exception = Assert.Throws<InvalidAttributeException>(() => new ProductId(invalidEmptyId));

            Assert.Pass(Exception.Message, InvalidAttributeException.FromEmpty("UUID"));
            Assert.IsInstanceOf<InvalidUUIDException>(Exception);
        }

        [Test]
        public void ItShouldThrowExceptionFromInvalidFormat()
        {
            string invalidId = "123456789";

            var Exception = Assert.Throws<InvalidAttributeException>(() => new ProductId(invalidId));

            Assert.Pass(Exception.Message, InvalidAttributeException.FromValue("UUID", invalidId));
            Assert.IsInstanceOf<InvalidUUIDException>(Exception);
        }

        [Test]
        public void ItShouldCreateNewProductId()
        {
            string id = "a742aea9-1923-45bd-903e-b0210436d6c2";

            ProductId productId = new ProductId(id);

            Assert.IsNotNull(productId);
            Assert.AreEqual(productId.GetValue(), id);
        }

        [Test]
        public void ItShouldReturnTrueWhenTwoProductIdAreEqual()
        {
            string id = "a742aea9-1923-45bd-903e-b0210436d6c2";

            ProductId productId1 = new ProductId(id);
            ProductId productId2 = new ProductId(id);

            Assert.IsTrue(productId1.Equals(productId2));
        }
    }
}
