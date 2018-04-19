using NUnit.Framework;
using System.Collections.Generic;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {
        [Test]
        public void Quality_DegradesByDouble_WhenOutOfDate()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 24 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(22, Items[0].Quality);
        }
        [Test]
        public void Quality_NeverNegative()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = -4, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(0, Items[0].Quality);
        }
        [Test]
        public void AgedBrie_Increases()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 5, Quality = 3 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(4, Items[0].Quality);
        }
        [Test]
        public void Quality_WillNotExceedMaxThreshold()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 2, Quality = 50 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(50, Items[0].Quality);
        }
        [Test]
        public void Sulfuras_DoesNotDecrement_Quality()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(80, Items[0].Quality);
        }
        [Test]
        public void BackStagePassQuality_IncreasesByTwo_WhenTenDaysOrLess()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 9, Quality = 25 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(27, Items[0].Quality);
        }
        [Test]
        public void BackStagePassQuality_IncreasesByThree_WhenFiveDaysOrLess()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 4, Quality = 25 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(28, Items[0].Quality);
        }
        [Test]
        public void BackStagePassQuality_REturnsToZero_WhenDayIsZero()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 25 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(0, Items[0].Quality);
        }
        [Test]
        public void ConjuredItemsQuality_DegradesDouble()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = 5, Quality = 8 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(6, Items[0].Quality);
        }
    }
}
