using GildedRose.App.Items;

namespace GildedRose.App.Update.Updaters
{
    public class GeneralUpdater : IUpdater
    {
        public void Update(Item item)
        {
            UpdateTools.DecreaseSellIn(item);

            UpdateTools.DecreaseQuality(item);

            UpdateTools.DecreaseQualityFromSellIn(item);
        }
    }
}
