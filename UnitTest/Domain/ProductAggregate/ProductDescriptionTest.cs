using BlockbusterApp.src.Domain.ProductAggregate;
using BlockbusterApp.src.Domain.ProductAggregate.Exception;
using BlockbusterApp.src.Shared.Domain.Exception;
using NUnit.Framework;
using UnitTest.Shared.Helper;

namespace UnitTest.Domain.ProductAggregate
{
    [TestFixture]
    public class ProductDescriptionTest
    {
        [Test]
        public void ItShouldThrowExceptionFromMaxLength()
        {
            string invalidDescription = StringHelper.GenerateRandomStringOfSetLength(2000);

            var Exception = Assert.Throws<InvalidAttributeException>(() => new ProductDescription(invalidDescription));

            Assert.Pass(Exception.Message, InvalidAttributeException.FromMaxLength("name", ProductDescription.MAX_LENGTH));
            Assert.IsInstanceOf<InvalidProductAttributeException>(Exception);
        }

        [Test]
        public void ItShouldThrowExceptionFromMinLength()
        {
            string invalidDescription = "aa";

            var Exception = Assert.Throws<InvalidAttributeException>(() => new ProductDescription(invalidDescription));

            Assert.Pass(Exception.Message, InvalidAttributeException.FromMinLength("name", ProductDescription.MIN_LENGTH));
            Assert.IsInstanceOf<InvalidProductAttributeException>(Exception);
        }

        [Test]
        public void ItShouldCreateNewProductDescription()
        {
            string description = "it is a war film";

            ProductDescription productDescription = new ProductDescription(description);

            Assert.IsNotNull(productDescription);
            Assert.AreEqual(productDescription.GetValue(), description);
        }

        [Test]
        public void ItShouldReturnTrueWhenTwoProductDescriptionAreEqual()
        {
            string description = "it is a war film";

            ProductDescription productDescription1 = new ProductDescription(description);
            ProductDescription productDescription2 = new ProductDescription(description);

            Assert.IsTrue(productDescription1.Equals(productDescription2));
        }
    }
}
