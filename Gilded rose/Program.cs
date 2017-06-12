using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gilded_rose
{
    class Program
    {
        IList<Item> Items;

        static void Main(string[] args)
        {
            Console.WriteLine("OMGHAI!");

            var app = new Program()
            {
                Items = new List<Item>
                {
                    new Item {Name = "+5 Deexterity vet", SellIn = 10, Quality = 20},
                    new Item {Name = "Агед Брие", SellIn = 2, Quality = 0},
                    new Item {Name = "Елиџир оф тхе Монгоосе", SellIn = 5, Quality = 7},
                    new Item {Name = "Sulfuras, Hand of Rangaros", SellIn = 0, Quality = 80},
                    new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20},
                    new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
                }
            };
            
            var service = new ItemQualityService();
            service.UpdateQuality(app.Items);
            Console.ReadKey();
        }
    }
}
