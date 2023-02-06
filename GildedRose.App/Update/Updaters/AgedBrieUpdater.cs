using GildedRose.App.Items;

namespace GildedRose.App.Update.Updaters
{
    public class AgedBrieUpdater : IUpdater
    {
        public void Update(Item item)
        {
            UpdateTools.DecreaseSellIn(item);

            if (item.Quality < UpdateTools.MaximumQuality)
            {
                UpdateTools.IncreaseQuality(item);
            }

            if (item.Quality < UpdateTools.MaximumQuality && item.SellIn < UpdateTools.MinimumSellIn)
            {
                UpdateTools.IncreaseQuality(item);
            }
        }
    }
}
