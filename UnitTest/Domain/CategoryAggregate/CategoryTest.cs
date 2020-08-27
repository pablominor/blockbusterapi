using BlockbusterApp.src.Domain.CategoryAggregate;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using UnitTest.Domain.CategoryAggregate.Stub;

namespace UnitTest.Domain.CategoryAggregate
{
    [TestFixture]
    public class CategoryTest
    {

        [Test]
        public void ItShouldCreateNewCategory()
        {
            CategoryId id = CategoryIdStub.ByDefault();
            CategoryName name = CategoryNameStub.ByDefault();

            Category category = Category.Create(id, name);

            Assert.IsNotNull(category);
            Assert.IsTrue(category.id.Equals(id));
            Assert.IsTrue(category.name.Equals(name));
        }

    }
}
