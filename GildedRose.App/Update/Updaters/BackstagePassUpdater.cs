using GildedRose.App.Items;

namespace GildedRose.App.Update.Updaters
{
    public class BackstagePassUpdater : IUpdater
    {
        public void Update(Item item)
        {
            if (item.SellIn < 0)
            {
                item.Quality = 0;
                UpdateTools.DecreaseSellIn(item);

                return;
            }

            UpdateTools.IncreaseQuality(item);

            if (item.SellIn <= 10)
            {
                UpdateTools.IncreaseQuality(item);
            }

            if (item.SellIn <= 5)
            {
                UpdateTools.IncreaseQuality(item);
            }

            UpdateTools.DecreaseSellIn(item);
        }
    }
}
