using BlockbusterApp.src.Domain.CategoryAggregate;
using NUnit.Framework;
using System;

namespace UnitTest.Domain.CategoryAggregate
{
    [TestFixture]
    public class CategoryUpdatedAtTest
    {

        [Test]
        public void ItShouldCreateNewCategoryUpdatedAt()
        {
            DateTime dateTime = DateTime.Now;

            CategoryUpdatedAt categoryUpdatedAt = new CategoryUpdatedAt(dateTime);

            Assert.IsNotNull(categoryUpdatedAt);
            Assert.AreEqual(categoryUpdatedAt.GetValue(), dateTime);
        }

    }
}
