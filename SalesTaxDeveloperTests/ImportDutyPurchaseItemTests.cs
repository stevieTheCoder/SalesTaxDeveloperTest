using SalesTaxDeveloperTest.Items;
using Xunit;

namespace SalesTaxDeveloperTests
{
    public class ImportDutyPurchaseItemTests
    {
        [Fact]
        public void GetPrice_Returns_PriceWithTax()
        {
            var purchaseItem = new PurchaseItem("withDuty", 11.25m);

            var withDuty = new ImportDutyPurchaseItem(purchaseItem);

            Assert.Equal(11.85m, withDuty.GetPrice());
        }

        [Fact]
        public void GetPrice_Returns_PriceWithTax_For_ItemWithPurchaseTax_And_ImportTax()
        {
            var purchaseItem = new PurchaseItem("withDuty", 47.50m);

            var withTax = new BasicTaxPurchaseItem(purchaseItem);

            var withDutyAndTax = new ImportDutyPurchaseItem(withTax);

            Assert.Equal(54.65m, withDutyAndTax.GetPrice());
        }
    }
}
