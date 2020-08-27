using BlockbusterApp.src.Domain.ProductAggregate;
using NUnit.Framework;
using UnitTest.Domain.ProductAggregate.Stub;

namespace UnitTest.Domain.ProductAggregate
{
    [TestFixture]
    public class ProductTest
    {
        [Test]
        public void ItShouldCreateNewProduct()
        {
            ProductId id = ProductIdStub.ByDefault();
            ProductName name = ProductNameStub.ByDefault();
            ProductDescription description = ProductDescriptionStub.ByDefault();
            ProductPrice price = ProductPriceStub.ByDefault();
            ProductCategoryId categoryId = ProductCategoryIdStub.ByDefault();

            Product product = Product.Create(id, name,description,price,categoryId);

            Assert.IsNotNull(product);
            Assert.IsTrue(product.id.Equals(id));
            Assert.IsTrue(product.name.Equals(name));
            Assert.IsTrue(product.description.Equals(description));
            Assert.IsTrue(product.price.Equals(price));
            Assert.IsTrue(product.categoryId.Equals(categoryId));
        }

        [TestCase("civil war","film about american captain",10.5, "3debbe23-f331-40b9-95dc-43148c705fc9")]
        [TestCase("avengers", "film about avengers", 20.5, "3debbe23-f331-40b9-95dc-43148c705fd2")]
        [TestCase("pulp fiction", "Pulp Fiction is a 1994 American neo-noir black comedy crime film", 50, "3debbe23-f331-40b9-95dc-43148c705fc9")]
        public void ItShouldUpdateValuesWhenAreDifferent(string name, string description, decimal price, string categoryId)
        {
            BlockbusterApp.src.Domain.ProductAggregate.Product product = ProductStub.ByDefault();
            ProductName productName = new ProductName(name);
            ProductDescription productDescription = new ProductDescription(description);
            ProductPrice productPrice = new ProductPrice(price);
            ProductCategoryId productCategoryId = new ProductCategoryId(categoryId);

            product.Update(productName, productDescription, productPrice, productCategoryId);

            Assert.IsTrue(product.name.Equals(productName));
            Assert.IsTrue(product.description.Equals(productDescription));
            Assert.IsTrue(product.price.Equals(productPrice));
            Assert.IsTrue(product.categoryId.Equals(productCategoryId));
        }


    }
}
