using FluentAssertions;
using Gilded_rose;
using Gilded_rose.Strategies;
using Xunit;

namespace GildedRose.UnitTests.Strategies
{
    public class BetterWithTimeUpdateQualityStrategyUpdateQualityShould : BaseStrategyTest
    {
        private BetterWithTimeUdpateQualityStrategy _strategy = new BetterWithTimeUdpateQualityStrategy();

        [Fact]
        public void IncreaseQualityOfAgeBrie()
        {
            var agedBrie = GetAgedBrie();
            var startingQuality = agedBrie.Quality;
            _strategy.UpdateQuality(agedBrie);

            agedBrie.Quality.Should().Be(startingQuality + 1);
        }


        [Fact]
        public void NotIncreaseQualityOfAgedBriePast50()
        {
            var agedBrie = GetAgedBrie(quality: SystemMaxQuality);
            var startingQuality = agedBrie.Quality;
            _strategy.UpdateQuality(agedBrie);

            agedBrie.Quality.Should().Be(startingQuality);
        }

        [Fact]
        public void IncreaseQualityOfAgeBrieBy2AfterSellIn()
        {
            var agedBrie = GetAgedBrie(sellIn: 0);
            var startingQuality = agedBrie.Quality;
            _strategy.UpdateQuality(agedBrie);

            agedBrie.Quality.Should().Be(startingQuality + 2);
        }

        private static StoreItem GetAgedBrie(int sellIn = DefaultStartingSellin, int quality = DefaultStartingQuality)
        {
            return new StoreItem(new Item { Name = "Aged Brie", SellIn = sellIn, Quality = quality });
        }
    }
}
