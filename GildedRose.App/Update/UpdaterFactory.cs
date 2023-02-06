using GildedRose.App.Items;
using GildedRose.App.Update.Updaters;

namespace GildedRose.App.Update
{
    public static class UpdaterFactory
    {
        public static IUpdater Create(Item item)
        {
            if (item.Name.Contains("Aged"))
            {
                return new AgedBrieUpdater();
            }
            else if (item.Name.Contains("Conjured"))
            {
                return new ConjuredUpdater();
            }
            else if (item.Name.Contains("Sulfuras"))
            {
                return new SulfrasUpdater();
            }
            else if (item.Name.Contains("Backstage"))
            {
                return new BackstagePassUpdater();
            }
            else
            {
                return new GeneralUpdater();
            }
        }
    }
}
