using GildedRose.App.Items;

namespace GildedRose.App.Update.Updaters
{
    public class BackstagePassUpdater : IUpdater
    {
        public void Update(Item item)
        {
            UpdateTools.DecreaseSellIn(item);

            if (item.SellIn < 0)
            {
                item.Quality = 0;

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
        }
    }
}
