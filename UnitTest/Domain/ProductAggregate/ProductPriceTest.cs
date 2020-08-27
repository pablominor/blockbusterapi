using BlockbusterApp.src.Domain.ProductAggregate;
using BlockbusterApp.src.Domain.ProductAggregate.Exception;
using BlockbusterApp.src.Shared.Domain.Exception;
using NUnit.Framework;

namespace UnitTest.Domain.ProductAggregate
{
    [TestFixture]
    public class ProductPriceTest
    {
        [Test]
        public void ItShouldThrowExceptionFromZero()
        {
            decimal invalidPrice = 0;

            var Exception = Assert.Throws<InvalidAttributeException>(() => new ProductPrice(invalidPrice));

            Assert.Pass(Exception.Message, InvalidAttributeException.FromValue("price", invalidPrice.ToString()));
            Assert.IsInstanceOf<InvalidProductAttributeException>(Exception);
        }


        [Test]
        public void ItShouldCreateNewProductPrice()
        {
            decimal price = new decimal(10.21);

            ProductPrice productPrice = new ProductPrice(price);

            Assert.IsNotNull(productPrice);
            Assert.AreEqual(productPrice.GetValue(), price);
        }

        [Test]
        public void ItShouldReturnTrueWhenTwoProductPriceAreEqual()
        {
            decimal price = new decimal(10.21);

            ProductPrice productPrice1 = new ProductPrice(price);
            ProductPrice productPrice2 = new ProductPrice(price);

            Assert.IsTrue(productPrice1.Equals(productPrice2));
        }
    }
}
