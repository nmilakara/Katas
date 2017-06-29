namespace Gilded_rose.Strategies
{
    public class DefaultUpdateQualityStrategy : IUpdateQualityStrategy
    {
        public void UpdateQuality(StoreItem item)
        {
            if (item.SellIn > 0)
            {
                item.SellIn--;
            }

            if (item.Quality > 0)
            {
                item.Quality--;

                if (item.SellIn < 1 && item.Quality > 0)
                {
                    item.Quality--;
                }
            }
        }
    }
}