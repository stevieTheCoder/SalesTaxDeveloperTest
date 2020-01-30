using SalesTaxDeveloperTest.Services;
using System;
using Xunit;

namespace SalesTaxDeveloperTests
{
    public class DeserialisationTests
    {
        [Fact]
        public void CreatePurchaseItem_Returns_Correct_Quantity()
        {
            var deserialisationService = new DeserialisationService();

            var (quantity, _) = deserialisationService.CreatePurchaseItem("1 book at £12.49");

            Assert.Equal(1, quantity);
        }

        [Theory]
        [InlineData("1 book at £12.49", 12.49)]
        [InlineData("1 box of imported chocolates at 11.25", 11.25)]
        [InlineData("1 bottle of perfume at £18.99", 18.99)]
        public void CreatePurchaseItem_Returns_Correct_Price(string item, decimal expected)
        {
            var deserialisationService = new DeserialisationService();

            var (_, purchaseItem) = deserialisationService.CreatePurchaseItem(item);

            Assert.Equal(expected, purchaseItem.OriginalPrice);
        }

        [Theory]
        [InlineData("1 imported bottle of perfume at £47.50", "imported bottle of perfume")]
        [InlineData("1 music CD at £14.99", "music CD")]
        [InlineData("1 chocolate bar at £0.85", "chocolate bar")]
        [InlineData("1 packet of headache pills at £9.75", "packet of headache pills")]
        public void CreatePurchaseItem_Returns_Correct_Description(string item, string expected)
        {
            var deserialisationService = new DeserialisationService();

            var (_, purchaseItem) = deserialisationService.CreatePurchaseItem(item);

            // Works whether this is whitespace
            Assert.Equal(expected, purchaseItem.Description);
        }
    }
}
