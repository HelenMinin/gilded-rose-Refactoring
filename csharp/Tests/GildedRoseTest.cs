using csharp.Items;
using NUnit.Framework;
using System.Collections.Generic;
using csharp.Const;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {
        [Test]
        public void GildedRose_UpdateQuality_QualityDegradesTwiceAsFast_WhenTheSellByDateHasPassed(
            [Values(0, -10, -20)] int sellIn,
            [Range(2, 50)] int quality)
        {
            //Arrange
            var items = new List<Item>
            {
                new Item { Name = "product", SellIn = sellIn, Quality = quality }
            };

            //Act
            GildedRose app = new GildedRose(items);
            app.UpdateQuality();

            //Assert
            Assert.AreEqual(quality - 2, items[0].Quality);
        }

        [Test]
        public void GildedRose_UpdateQuality_QualityCannotBeLessThanZero(
            [Values(5, 0, -5)] int sellIn,
            [Range(0, 50)] int quality)
        {
            //Arrange
            var items = new List<Item>
            {
                new Item { Name = "product", SellIn = sellIn, Quality = quality }
            };

            //Act
            GildedRose app = new GildedRose(items);
            app.UpdateQuality();

            //Assert
            Assert.IsTrue(items[0].Quality >= 0);
        }

        [Test]
        public void GildedRose_UpdateQuality_IncreaseAgedBrieProductQuality_WhenGetsOlder(
            [Range(0, -20)] int sellIn)
        {
            //Arrange
            var quality = 20;
            var items = new List<Item>
            {
                new Item { Name = TypeItem.AgedBrie, SellIn = sellIn, Quality = quality }
            };

            //Act
            GildedRose app = new GildedRose(items);
            app.UpdateQuality();

            //Assert
            Assert.AreEqual(quality + 1, items[0].Quality);
        }

        [TestCase(TypeItem.AgedBrie)]
        [TestCase(TypeItem.Backstage)]
        public void GildedRose_UpdateQuality_QualityDoesntIncreaseMoreThanFifty(
            string productName)
        {
            //Arrange
            var items = new List<Item>
            {
                new Item { Name = productName, SellIn = 10, Quality = 50 }
            };

            //Act
            GildedRose app = new GildedRose(items);
            app.UpdateQuality();

            //Assert
            Assert.IsTrue(items[0].Quality == 50);
        }

        [Test]
        public void GildedRose_UpdateQuality_SufurasProductNeverHasToBeSoldOrDecreasesInQuality(
            [Range(-5, 5)] int sellIn,
            [Values(10, 25, 50)] int quality)
        {
            //Arrange
            var items = new List<Item>
            {
                new Item { Name = TypeItem.Sulfuras, SellIn = sellIn, Quality = quality }
            };

            //Act
            GildedRose app = new GildedRose(items);
            app.UpdateQuality();

            //Assert
            Assert.AreEqual(sellIn, items[0].SellIn);
            Assert.AreEqual(quality, items[0].Quality);
        }

        [Test]
        public void GildedRose_UpdateQuality_IncreaseBackstagePassesProductQualityBy1_WhenSellInIsMoreThan10Days(
            [Range(11, 20)] int sellIn)
        {
            //Arrange
            var quality = 0;
            var items = new List<Item>
            {
                new Item { Name = TypeItem.Backstage, SellIn = sellIn, Quality = quality }
            };

            //Act
            GildedRose app = new GildedRose(items);
            app.UpdateQuality();

            //Assert
            Assert.AreEqual(quality + 1, items[0].Quality);
        }

        [Test]
        public void GildedRose_UpdateQuality_IncreaseBackstagePassesProductQualityBy2_WhenSellInIsBetween10And6Days(
            [Range(6, 10)] int sellIn)
        {
            //Arrange
            var quality = 0;
            var items = new List<Item>
            {
                new Item { Name = TypeItem.Backstage, SellIn = sellIn, Quality = quality }
            };

            //Act
            GildedRose app = new GildedRose(items);
            app.UpdateQuality();

            //Assert
            Assert.AreEqual(quality + 2, items[0].Quality);
        }


        [Test]
        public void GildedRose_UpdateQuality_IncreaseBackstagePassesProductQualityBy3_WhenSellInIsBetween5And1Day(
            [Range(1, 5)] int sellIn)
        {
            //Arrange
            var quality = 0;
            var items = new List<Item>
            {
                new Item { Name = TypeItem.Backstage, SellIn = sellIn, Quality = quality }
            };

            //Act
            GildedRose app = new GildedRose(items);
            app.UpdateQuality();

            //Assert
            Assert.AreEqual(quality + 3, items[0].Quality);
        }


        [Test]
        public void GildedRose_UpdateQuality_BackstagePassesProductQualityDropsTo0_WhenConcertIsOver(
            [Values(0, -5, -10)] int sellIn,
            [Range(0, 50)] int quality)
        {
            //Arrange
            var items = new List<Item>
            {
                new Item { Name = TypeItem.Backstage, SellIn = sellIn, Quality = quality }
            };

            //Act
            GildedRose app = new GildedRose(items);
            app.UpdateQuality();

            //Assert
            Assert.AreEqual(0, items[0].Quality);
        }

        [Test]
        public void GildedRose_UpdateQuality_ConjuredProductDegradesTwiceAsFastThanNormalItems_WhenTheSaleDateHasNotPassed(
            [Range(10, 1)] int sellIn,
            [Range(2, 50)] int quality)
        {
            //Arrange
            var items = new List<Item>
            {
                new Item { Name = TypeItem.Conjured, SellIn = sellIn, Quality = quality }
            };

            //Act
            GildedRose app = new GildedRose(items);
            app.UpdateQuality();

            //Assert
            Assert.AreEqual(quality - 2 , items[0].Quality);
        }

        [Test]
        public void GildedRose_UpdateQuality_ConjuredProductDegradesTwiceAsFastThanNormalItems_WhenTheSaleDateHasPassed(
            [Range(0, -10)] int sellIn,
            [Range(4, 50)] int quality)
        {
            //Arrange
            var items = new List<Item>
            {
                new Item { Name = TypeItem.Conjured, SellIn = sellIn, Quality = quality }
            };

            //Act
            GildedRose app = new GildedRose(items);
            app.UpdateQuality();

            //Assert
            Assert.AreEqual(quality - 4, items[0].Quality);
        }

        [Test]
        public void GildedRose_UpdateQuality_QualityDegradesWithThePassingDays(
            [Range(6, 10)] int sellIn,
            [Range(10, 50)] int quality)
        {
            //Arrange
            var items = new List<Item>
            {
                new Item { Name ="Product", SellIn = sellIn, Quality = quality }
            };

            //Act
            GildedRose app = new GildedRose(items);
            app.UpdateQuality();

            //Assert
            Assert.AreEqual(quality - 1, items[0].Quality);
            Assert.AreEqual(sellIn - 1, items[0].SellIn);
        }
    }
}
