using GildedRose.App.Items;
using GildedRose.App.Update;

namespace GildedRose.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("OMGHAI!");

            List<Item> Items = ItemsFactory.Create();

            UpdateTools.UpdateItems(Items);

            for (var i = 0; i < 31; i++)
            {
                Console.WriteLine("-------- day " + i + " --------");

                foreach (Item item in Items)
                {
                    Console.WriteLine($"Name: {item.Name}, Sell In: {item.SellIn}, Quality {item.Quality}");
                }
            }
        }
    }
}
