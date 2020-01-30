using SalesTaxDeveloperTest.Items;
using SalesTaxDeveloperTest.Output;
using Xunit;

namespace SalesTaxDeveloperTests
{
    public class ReceiptTests
    {
        [Fact]
        public void AddPurchaseItem_AddsItem_ToCollection()
        {
            var receipt = new Receipt();

            receipt.AddPurchaseItem(new PurchaseItem("test", 15.99m));

            Assert.Single(receipt.PurchaseItems);
        }

        [Fact]
        public void AddPurchaseItem_AddsTax_ToSalesTaxes()
        {
            var receipt = new Receipt();

            var purchaseItem = new PurchaseItem("test", 14.99m);

            receipt.AddPurchaseItem(new BasicTaxPurchaseItem(purchaseItem));

            Assert.Equal(1.50m, receipt.SalesTaxes);
        }

        [Fact]
        public void AddPurchaseItem_AddsPrice_ToTotal()
        {
            var receipt = new Receipt();

            var purchaseItem = new PurchaseItem("test", 14.99m);

            var purchaseItem2 = new PurchaseItem("anotherTest", 10);

            receipt.AddPurchaseItem(new BasicTaxPurchaseItem(purchaseItem));
            receipt.AddPurchaseItem(purchaseItem2);

            Assert.Equal(26.49m, receipt.Total);
        }
    }
}
