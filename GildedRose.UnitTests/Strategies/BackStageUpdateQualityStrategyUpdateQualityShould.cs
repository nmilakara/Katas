using FluentAssertions;
using Gilded_rose;
using Gilded_rose.Strategies;
using Xunit;

namespace GildedRose.UnitTests.Strategies
{
    public class BackStageUpdateQualityStrategyUpdateQualityShould : BaseStrategyTest
    {
        private BackStagePassUpdateQualityStrategy _strategy = new BackStagePassUpdateQualityStrategy();

        [Fact]
        public void IncreaseQualityOfBackstagePassesByOneWith11DaysLeft()
        {
            var backstagePasses = GetBackstagePasses(sellIn: 11);
            var startingQuality = backstagePasses.Quality;
            _strategy.UpdateQuality(backstagePasses);

            backstagePasses.Quality.Should().Be(startingQuality + 1);
        }

        [Fact]
        public void IncreaseQualityOfBackstagePassesByTwoWith10DaysLeft()
        {
            var backstagePasses = GetBackstagePasses(sellIn: 10);
            var startingQuality = backstagePasses.Quality;
            _strategy.UpdateQuality(backstagePasses);

            backstagePasses.Quality.Should().Be(startingQuality + 2);
        }

        // test edge cases for range between 5 and 10 (6 is the edge case)
        [Fact]
        public void IncreaseQualityOfBackstagePassesByTwoWith6DaysLeft()
        {
            var backstagePasses = GetBackstagePasses(sellIn: 6);
            var startingQuality = backstagePasses.Quality;
            _strategy.UpdateQuality(backstagePasses);

            backstagePasses.Quality.Should().Be(startingQuality + 2);
        }

        [Fact]
        public void IncreaseQualityOfBackstagePassesByThreeWith5DaysLeft()
        {
            var backstagePasses = GetBackstagePasses(sellIn: 5);
            var startingQuality = backstagePasses.Quality;
            _strategy.UpdateQuality(backstagePasses);

            backstagePasses.Quality.Should().Be(startingQuality + 3);
        }

        [Fact]
        public void IncreaseQualityOfBackstagePassesByThreeWith1DayLeft()
        {
            var backstagePasses = GetBackstagePasses(sellIn: 1);
            var startingQuality = backstagePasses.Quality;
            _strategy.UpdateQuality(backstagePasses);

            backstagePasses.Quality.Should().Be(startingQuality + 3);
        }

        [Fact]
        public void SetQualityOfBackstagePassesToZeroWith0DayLeft()
        {
            var backstagePasses = GetBackstagePasses(sellIn: 0);
            var startingQuality = backstagePasses.Quality;
            _strategy.UpdateQuality(backstagePasses);

            backstagePasses.Quality.Should().Be(0);
        }

        private static StoreItem GetBackstagePasses(int sellIn = 15, int quality = DefaultStartingQuality)
        {
            return new StoreItem(new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellIn, Quality = quality });
        }
    }
}
