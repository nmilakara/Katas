using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gilded_rose
{
    public class StoreItem
    {
        private readonly Item _item;

        public StoreItem()
        {
                
        }

        public StoreItem(Item item)
        {
            _item = item;
        }

        public string Name
        {
            get { return _item.Name; }
            set { _item.Name = value; }
        }

        public int Quality
        {
            get { return _item.Quality; }
            set { _item.Quality = value; }
        }
        
        public int SellIn
        {
            get { return _item.SellIn; }
            set { _item.SellIn = value; }
        }

        public void UpdateQuality()
        {
            if (Name != "Aged Brie" && Name != "Backstage passes to a TAFKAL80ETC concert")
            {
                if (Quality > 0)
                {
                    if (Name != "Sulfuras, Hand of Ragnaros")
                    {
                        Quality = Quality - 1;
                    }
                }
            }
            else
            {
                if (Quality < 50)
                {
                    Quality = Quality + 1;

                    if (Name == "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (SellIn < 11)
                        {
                            if (Quality < 50)
                            {
                                Quality = Quality + 1;
                            }
                        }

                        if (SellIn < 6)
                        {
                            if (Quality < 50)
                            {
                                Quality = Quality + 1;
                            }
                        }
                    }
                }
            }

            if (Name != "Sulfuras, Hand of Ragnaros")
            {
                SellIn = SellIn - 1;
            }

            if (SellIn < 0)
            {
                if (Name != "Aged Brie")
                {
                    if (Name != "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (Quality > 0)
                        {
                            if (Name != "Sulfuras, Hand of Ragnaros")
                            {
                                Quality = Quality - 1;
                            }
                        }
                    }
                    else
                    {
                        Quality = Quality - Quality;
                    }
                }
                else
                {
                    if (Quality < 50)
                    {
                        Quality = Quality + 1;
                    }
                }
            }
        }
    }
}
