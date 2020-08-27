using BlockbusterApp.src.Domain.CategoryAggregate;
using NUnit.Framework;
using System;

namespace UnitTest.Domain.CategoryAggregate
{
    [TestFixture]
    public class CategoryCreatedAtTest
    {

        [Test]
        public void ItShouldCreateNewCategoryCreatedAt()
        {
            DateTime dateTime = DateTime.Now;

            CategoryCreatedAt categoryCreatedAt = new CategoryCreatedAt(dateTime);

            Assert.IsNotNull(categoryCreatedAt);
            Assert.AreEqual(categoryCreatedAt.GetValue(), dateTime);
        }

    }
}
