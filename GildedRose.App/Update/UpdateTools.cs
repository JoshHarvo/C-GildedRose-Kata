using GildedRose.App.Items;

namespace GildedRose.App.Update
{
    public static class UpdateTools
    {
        public static int MaximumQuality = 50;
        public static int MinimumQuality = 0;
        public static int MinimumSellIn = 0;

        public static void UpdateItems(List<Item> items)
        {
            foreach (Item item in items)
            {
                IUpdater updater = UpdaterFactory.Create(item);
                updater.Update(item);
            }
        }

        public static void IncreaseQuality(Item item)
        {
            if (item.Quality < MaximumQuality)
            {
                item.Quality++;
            }
        }

        public static void DecreaseQuality(Item item)
        {
            if (item.Quality > MinimumQuality)
            {
                item.Quality--;
            }
        }

        public static void DecreaseSellIn(Item item)
        {
            item.SellIn--;
        }

        public static void DecreaseQualityFromSellIn(Item item)
        {
            if (item.SellIn < MinimumSellIn && item.Quality > MinimumQuality)
            {
                item.Quality--;
            }
        }
    }
}
