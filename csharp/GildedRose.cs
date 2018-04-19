using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
       private const int maxThreshold = 50;
       private const string BackstagePasses = "Backstage passes to a TAFKAL80ETC concert";
       private const string AgedBrie = "Aged Brie";
       private const string SulfurasHandOfRagnaros = "Sulfuras, Hand of Ragnaros";
       private const string ConjuredManaCake = "Conjured Mana Cake";

        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                UpdateQualityWithinSellByDate(item);

                if (item.Name != SulfurasHandOfRagnaros)
                    item.SellIn--;

                if (item.SellIn < 0)
                    UpdateQualityOutOfSellByDate(item);
            }
         
        }
        private void UpdateQualityWithinSellByDate(Item item)
        {
            switch (item.Name)
            {
                case AgedBrie:
                    IncreaseQuality(item);
                    break;
                case BackstagePasses:
                    IncreaseQuality(item);
                    HandleBackstagePass(item);
                    break;
                case SulfurasHandOfRagnaros:
                    break;
                case ConjuredManaCake:
                    DecreaseQuality(item, 2);
                    break;
                default:
                    if (item.Quality > 0)
                        DecreaseQuality(item);
                    break;
            }
        }
        private void UpdateQualityOutOfSellByDate(Item item)
        {
            switch (item.Name)
            {
                case AgedBrie:
                    IncreaseQuality(item);
                    break;
                case BackstagePasses:
                    item.Quality = 0;
                    break;
                case SulfurasHandOfRagnaros:
                    break;
                case ConjuredManaCake:
                    DecreaseQuality(item, 2);
                    break;
                default:
                    if (item.Quality > 0)
                        DecreaseQuality(item);
                    break;
            }
        }
        private void DecreaseQuality(Item item, int qualityDecrease = 1)
        {
            item.Quality -= qualityDecrease;
        }
        private void HandleBackstagePass(Item item)
        {
            if (item.SellIn < 11 && item.SellIn >= 6)
                IncreaseQuality(item);

            else if (item.SellIn < 6)
                IncreaseQuality(item, 2);
        }
        private void IncreaseQuality(Item item, int qualityIncrease = 1)
        {
            item.Quality = System.Math.Min(maxThreshold, item.Quality + qualityIncrease);
        }
    }
}
