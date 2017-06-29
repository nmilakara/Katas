using FluentAssertions;
using Gilded_rose;
using Gilded_rose.Strategies;
using Xunit;

namespace GildedRose.UnitTests.Strategies
{
    public class DefaultUpdateQualityStrategyUpdateQualityShould : BaseStrategyTest
    {
        private DefaultUpdateQualityStrategy _strategy = new DefaultUpdateQualityStrategy();

        [Fact]
        public void ReduceNormalItemQualityByOne()
        {
            var normalItem = GetNormalItem();
            var startingQuality = normalItem.Quality;
            _strategy.UpdateQuality(normalItem);

            normalItem.Quality.Should().Be(startingQuality - 1);
        }

        [Fact]
        public void ReduceNormalItemSellInByOne()
        {
            var normalItem = GetNormalItem();
            var startingSellin = normalItem.SellIn;
            _strategy.UpdateQuality(normalItem);

            // startingSellin - 1 - much more expressive then to put magic number 9.
            normalItem.SellIn.Should().Be(startingSellin - 1);
        }

        [Fact]
        public void ReduceNormalItemQualityByTwoWhenSellInLessThan1()
        {
            var normalItem = GetNormalItem(sellIn: 0);
            var startingQuality = normalItem.Quality;
            _strategy.UpdateQuality(normalItem);

            normalItem.Quality.Should().Be(startingQuality - 2);
        }

        [Fact]
        public void NotReduceQualityBelowZero()
        {
            var normalItem = GetNormalItem(quality: 0);
            _strategy.UpdateQuality(normalItem);

            normalItem.Quality.Should().Be(0);
        }

        private static StoreItem GetNormalItem(int sellIn = DefaultStartingSellin, int quality = DefaultStartingQuality)
        {
            return new StoreItem(new Item { Name = "+5 Deexterity vet", SellIn = sellIn, Quality = quality });
        }
    }
}
