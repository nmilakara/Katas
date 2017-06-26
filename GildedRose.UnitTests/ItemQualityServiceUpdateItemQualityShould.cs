using Xunit;
using System;
using FluentAssertions;
using Gilded_rose;

namespace GildedRose.UnitTests
{
    public class ItemQualityServiceUpdateItemQualityShould
    {
        private const int DEFAULT_STARTING_SELLIN = 10;
        private const int DEFAULT_STARTING_QUALITY = 20;

        public ItemQualityService ItemQualityService = new ItemQualityService();
        private int SYSTEM_MAX_QUALITY;


        [Fact]
        public void ReduceNormalItemQualityByOne()
        {
            var normalItem = GetNormalItem();
            var startingQuality = normalItem.Quality;

            normalItem.UpdateQuality();

            normalItem.Quality.Should().Be(startingQuality - 1);
        }

        [Fact]
        public void ReduceNormalItemSellInByOne()
        {
            var normalItem = GetNormalItem();
            var startingSellin = normalItem.SellIn;
            normalItem.UpdateQuality();

            // startingSellin - 1 - much more expressive then to put magic number 9.
            normalItem.SellIn.Should().Be(startingSellin - 1);
        }

        [Fact]
        public void ReduceNormalItemQualityByTwoWhenSellInLessThan1()
        {
            var normalItem = GetNormalItem(sellIn: 0);
            var startingQuality = normalItem.Quality;

            normalItem.UpdateQuality();

            normalItem.Quality.Should().Be(startingQuality - 2);
        }

        [Fact]
        public void NotReduceQualityBelowZero()
        {
            var normalItem = GetNormalItem(quality: 0);
            normalItem.UpdateQuality();

            normalItem.Quality.Should().Be(0);
        }

        [Fact]
        public void IncreaseQualityOfAgeBrie()
        {
            var agedBrie = GetAgedBrie();
            var startingQuality = agedBrie.Quality;
            agedBrie.UpdateQuality();

            agedBrie.Quality.Should().Be(startingQuality + 1);
        }


        [Fact]
        public void NotIncreaseQualityOfAgedBriePast50()
        {
            SYSTEM_MAX_QUALITY = 50;
            var agedBrie = GetAgedBrie(quality: SYSTEM_MAX_QUALITY);
            var startingQuality = agedBrie.Quality;
            agedBrie.UpdateQuality();

            agedBrie.Quality.Should().Be(startingQuality);
        }

        [Fact]
        public void IncreaseQualityOfAgeBrieBy2AfterSellIn()
        {
            var agedBrie = GetAgedBrie(sellIn: 0);
            var startingQuality = agedBrie.Quality;
            agedBrie.UpdateQuality();

            agedBrie.Quality.Should().Be(startingQuality + 2);
        }

        [Fact]
        public void NotChangeQualityOfSulfuras()
        {
            var sulfuras = GetSulfuras();
            var startingQuality = sulfuras.Quality;
            sulfuras.UpdateQuality();

            sulfuras.Quality.Should().Be(startingQuality);
        }

        [Fact]
        public void NotChangeSellInOfSulfuras()
        {
            var sulfuras = GetSulfuras();
            var startingSellin = sulfuras.SellIn;
            sulfuras.UpdateQuality();

            sulfuras.SellIn.Should().Be(startingSellin);
        }

        [Fact]
        public void IncreaseQualityOfBackstagePassesByOneWith11DaysLeft()
        {
            var backstagePasses = GetBackstagePasses(sellIn: 11);
            var startingQuality = backstagePasses.Quality;
            backstagePasses.UpdateQuality();

            backstagePasses.Quality.Should().Be(startingQuality + 1);
        }

        [Fact]
        public void IncreaseQualityOfBackstagePassesByTwoWith10DaysLeft()
        {
            var backstagePasses = GetBackstagePasses(sellIn: 10);
            var startingQuality = backstagePasses.Quality;
            backstagePasses.UpdateQuality();

            backstagePasses.Quality.Should().Be(startingQuality + 2);
        }

        // test edge cases for range between 5 and 10 (6 is the edge case)
        [Fact]
        public void IncreaseQualityOfBackstagePassesByTwoWith6DaysLeft()
        {
            var backstagePasses = GetBackstagePasses(sellIn: 6);
            var startingQuality = backstagePasses.Quality;
            backstagePasses.UpdateQuality();

            backstagePasses.Quality.Should().Be(startingQuality + 2);
        }

        [Fact]
        public void IncreaseQualityOfBackstagePassesByThreeWith5DaysLeft()
        {
            var backstagePasses = GetBackstagePasses(sellIn: 5);
            var startingQuality = backstagePasses.Quality;
            backstagePasses.UpdateQuality();

            backstagePasses.Quality.Should().Be(startingQuality + 3);
        }

        [Fact]
        public void IncreaseQualityOfBackstagePassesByThreeWith1DayLeft()
        {
            var backstagePasses = GetBackstagePasses(sellIn: 1);
            var startingQuality = backstagePasses.Quality;
            backstagePasses.UpdateQuality();

            backstagePasses.Quality.Should().Be(startingQuality + 3);
        }

        [Fact]
        public void SetQualityOfBackstagePassesToZeroWith0DayLeft()
        {
            var backstagePasses = GetBackstagePasses(sellIn: 0);
            var startingQuality = backstagePasses.Quality;
            backstagePasses.UpdateQuality();

            backstagePasses.Quality.Should().Be(0);
        }

        private static StoreItem GetNormalItem(int sellIn = DEFAULT_STARTING_SELLIN, int quality = DEFAULT_STARTING_QUALITY)
        {
            return new StoreItem(new Item { Name = "+5 Deexterity vet", SellIn = sellIn, Quality = quality });
        }

        private static StoreItem GetAgedBrie(int sellIn = DEFAULT_STARTING_SELLIN, int quality = DEFAULT_STARTING_QUALITY)
        {
            return new StoreItem(new Item { Name = "Aged Brie", SellIn = sellIn, Quality = quality });
        }

        private static StoreItem GetSulfuras()
        {
            return new StoreItem(new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 });
        }

        private static StoreItem GetBackstagePasses(int sellIn = 15, int quality = DEFAULT_STARTING_QUALITY)
        {
            return new StoreItem(new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellIn, Quality = quality });
        }
    }
}
