using Xunit;
using System;
using FluentAssertions;
using Gilded_rose;

namespace GildedRose.UnitTests
{
    public class ItemQualityServiceUpdateItemQualityShould
    {
        [Fact]
        public void ReduceNormalItemQualityByOne()
        {
            var qualityService = new ItemQualityService();
            var normalItem = new Item { Name = "+5 Deexterity vet", SellIn = 10, Quality = 20 };

            qualityService.UpdateQuality(normalItem);

            normalItem.Quality.Should().Be(19);
        }

        [Fact]
        public void ReduceNormalItemSellInByOne()
        {
            var qualityService = new ItemQualityService();
            var normalItem = new Item { Name = "+5 Deexterity vet", SellIn = 10, Quality = 20 };

            qualityService.UpdateQuality(normalItem);

            normalItem.SellIn.Should().Be(9);
        }
    }
}
