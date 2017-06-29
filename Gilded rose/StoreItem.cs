using Gilded_rose.Strategies;

namespace Gilded_rose
{
    public class StoreItem
    {
        private readonly Item _item;
        private readonly IUpdateQualityStrategy _updateQualityStrategy;

        public StoreItem()
        {

        }

        public StoreItem(Item item)
        {
            _item = item;

            // let's start with default strategy and change it where appropriate
            _updateQualityStrategy = new DefaultUpdateQualityStrategy();

            if (Name == "Aged Brie")
            {
                _updateQualityStrategy = new BetterWithTimeUdpateQualityStrategy();
            }

            if (Name == "Sulfuras, Hand of Ragnaros")
            {
                _updateQualityStrategy = new LegendaryUpdateQualityStrategy();
            }

            if (Name == "Backstage passes to a TAFKAL80ETC concert")
            {
                _updateQualityStrategy = new BackStagePassUpdateQualityStrategy();
            }
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
            _updateQualityStrategy.UpdateQuality(this);
        }
    }
}
