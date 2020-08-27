using BlockbusterApp.src.Domain.ProductAggregate;
using BlockbusterApp.src.Domain.ProductAggregate.Exception;
using BlockbusterApp.src.Shared.Domain.Exception;
using NUnit.Framework;
using UnitTest.Domain.ProductAggregate.Stub;

namespace UnitTest.Domain.ProductAggregate
{
    [TestFixture]
    public class ProductNameTest
    {
        [Test]
        public void ItShouldThrowExceptionFromMaxLength()
        {
            string invalidName = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";

            var Exception = Assert.Throws<InvalidAttributeException>(() => new ProductName(invalidName));

            Assert.Pass(Exception.Message, InvalidAttributeException.FromMaxLength("name", ProductName.MAX_LENGTH));
            Assert.IsInstanceOf<InvalidProductAttributeException>(Exception);
        }

        [Test]
        public void ItShouldThrowExceptionFromMinLength()
        {
            string invalidName = "aa";

            var Exception = Assert.Throws<InvalidAttributeException>(() => new ProductName(invalidName));

            Assert.Pass(Exception.Message, InvalidAttributeException.FromMinLength("name", ProductName.MIN_LENGTH));
            Assert.IsInstanceOf<InvalidProductAttributeException>(Exception);
        }

        [Test]
        public void ItShouldCreateNewProductName()
        {
            string name = "Action";

            ProductName productName = new ProductName(name);

            Assert.IsNotNull(productName);
            Assert.AreEqual(productName.GetValue(), name);
        }

        [Test]
        public void ItShouldReturnTrueWhenTwoProductNameAreEqual()
        {
            string name = "Action";

            ProductName productName1 = new ProductName(name);
            ProductName productName2 = new ProductName(name);

            Assert.IsTrue(productName1.Equals(productName2));
        }
    }
}
