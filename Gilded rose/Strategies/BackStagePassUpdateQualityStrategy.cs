namespace Gilded_rose.Strategies
{
    public class BackStagePassUpdateQualityStrategy : IUpdateQualityStrategy
    {
        public void UpdateQuality(StoreItem item)
        {
            if (item.Quality < 50)
            {
                item.Quality++;
            }

            item.SellIn--;



            if (item.SellIn < 10)
            {
                if (item.Quality < 50)
                {
                    item.Quality++;
                }
            }

            if (item.SellIn < 5)
            {
                if (item.Quality < 50)
                {
                    item.Quality++;
                }
            }

            if (item.SellIn < 0)
            {
                item.Quality = 0;
            }
        }
    }
}