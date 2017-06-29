using FluentAssertions;
using Gilded_rose;
using Gilded_rose.Strategies;
using Xunit;

namespace GildedRose.UnitTests.Strategies
{
    public class LegendaryUpdateItemQualityShould : BaseStrategyTest
    {
        private LegendaryUpdateQualityStrategy _strategy = new LegendaryUpdateQualityStrategy();

        [Fact]
        public void NotChangeQualityOfSulfuras()
        {
            var sulfuras = GetSulfuras();
            var startingQuality = sulfuras.Quality;
            _strategy.UpdateQuality(sulfuras);

            sulfuras.Quality.Should().Be(startingQuality);
        }

        [Fact]
        public void NotChangeSellInOfSulfuras()
        {
            var sulfuras = GetSulfuras();
            var startingSellin = sulfuras.SellIn;
            _strategy.UpdateQuality(sulfuras);

            sulfuras.SellIn.Should().Be(startingSellin);
        }

        private static StoreItem GetSulfuras()
        {
            return new StoreItem(new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 });
        }
    }
}
