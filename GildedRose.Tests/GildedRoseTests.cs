using FluentAssertions;
using GildedRose.App.Items;
using GildedRose.App.Update;
using GildedRose.App.Update.Updaters;
using Xunit;

namespace GildedRose.Tests
{
    public class TestAssemblyTests
    {
        [Fact]
        public void TestTheAppWithFullList()
        {
            List<Item> items = ItemsFactory.Create();

            UpdateTools.UpdateItems(items);

            items[0].Name.Should().Be("+5 Dexterity Vest");
            items[0].SellIn.Should().Be(9);
            items[0].Quality.Should().Be(19);

            items[1].Name.Should().Be("Aged Brie");
            items[1].SellIn.Should().Be(1);
            items[1].Quality.Should().Be(1);

            items[2].Name.Should().Be("Elixir of the Mongoose");
            items[2].SellIn.Should().Be(4);
            items[2].Quality.Should().Be(6);

            items[3].Name.Should().Be("Sulfuras, Hand of Ragnaros");
            items[3].SellIn.Should().Be(0);
            items[3].Quality.Should().Be(80);

            items[4].Name.Should().Be("Backstage passes to a TAFKAL80ETC concert");
            items[4].SellIn.Should().Be(4);
            items[4].Quality.Should().Be(50);

            items[5].Name.Should().Be("Conjured Mana Cake");
            items[5].SellIn.Should().Be(2);
            items[5].Quality.Should().Be(4);
        }

        [Theory]
        [InlineData("+5 Dexterity Vest", 10, 20, 9, 19)]
        [InlineData("Elixir of the Mongoose", 9, 0, 8, 0)]
        [InlineData("Elixir of the Mongoose", 0, 20, -1, 18)]
        [InlineData("Elixir of the Mongoose", 5, 7, 4, 6)]
        [InlineData("Sulfuras, Hand of Ragnaros", 0, 80, 0, 80)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 14, 20, 13, 21)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 11, 20, 10, 21)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 10, 20, 9, 22)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 6, 20, 5, 22)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 5, 20, 4, 23)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 0, 20, -1, 23)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", -1, 20, -2, 0)]
        [InlineData("Conjured Mana Cake", 3, 6, 2, 4)]
        [InlineData("Aged Brie", 2, 0, 1, 1)]
        [InlineData("Aged Brie", 2, 50, 1, 50)]
        [InlineData("Aged Brie", 0, 40, -1, 42)]
        public void TestIndividualScenarios(string name, int sellIn, int quality, int newSellIn, int newquality)
        {
            List<Item> item = new List<Item> { new Item { Name = name, Quality = quality, SellIn = sellIn } };

            UpdateTools.UpdateItems(item);

            item.Count().Should().Be(1);
            item[0].Name.Should().Be(name);
            item[0].SellIn.Should().Be(newSellIn);
            item[0].Quality.Should().Be(newquality);
        }

        [Fact]
        public void TestUpdaterFactory()
        {
            List<Item> items = ItemsFactory.Create();

            IUpdater updater = UpdaterFactory.Create(items[0]);
            updater.Should().NotBeNull();
            updater.Should().BeOfType<GeneralUpdater>();

            updater = UpdaterFactory.Create(items[1]);
            updater.Should().NotBeNull();
            updater.Should().BeOfType<AgedBrieUpdater>();

            updater = UpdaterFactory.Create(items[2]);
            updater.Should().NotBeNull();
            updater.Should().BeOfType<GeneralUpdater>();

            updater = UpdaterFactory.Create(items[3]);
            updater.Should().NotBeNull();
            updater.Should().BeOfType<SulfrasUpdater>();

            updater = UpdaterFactory.Create(items[4]);
            updater.Should().NotBeNull();
            updater.Should().BeOfType<BackstagePassUpdater>();

            updater = UpdaterFactory.Create(items[5]);
            updater.Should().NotBeNull();
            updater.Should().BeOfType<ConjuredUpdater>();
        }
    }
}