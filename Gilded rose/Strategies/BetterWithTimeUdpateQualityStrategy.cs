namespace Gilded_rose.Strategies
{
    public class BetterWithTimeUdpateQualityStrategy : IUpdateQualityStrategy
    {
        public void UpdateQuality(StoreItem item)
        {
            if (item.Quality < 50)
            {
                item.Quality++;
            }

            item.SellIn--;

            if (item.SellIn < 0)
            {
                item.Quality++;
            }
        }
    }
}