using SalesTaxDeveloperTest.Items;
using Xunit;

namespace SalesTaxDeveloperTests
{
    public class BasicTaxPurchaseItemTests
    {
        [Fact]
        public void GetPrice_Returns_PriceWithTax()
        {
            var purchaseItem = new PurchaseItem("withTax", 14.99m);

            var withTax = new BasicTaxPurchaseItem(purchaseItem);

            Assert.Equal(16.49m, withTax.GetPrice());
        }
    }
}
