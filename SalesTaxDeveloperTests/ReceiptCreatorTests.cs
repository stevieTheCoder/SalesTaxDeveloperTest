using SalesTaxDeveloperTest;
using SalesTaxDeveloperTest.Services;
using System.Collections.Generic;
using Xunit;

namespace SalesTaxDeveloperTests
{
    public class ReceiptCreatorTests
    {
        [Fact]
        public void CreateReceipt_ReturnsReceipt_WithItem()
        {
            var receiptCreator = new ReceiptCreator(new DeserialisationService(), new TaxDecoratorService());

            var items = new List<string>
            {
                "1 book at £12.49",
                "1 music CD at £14.99",
                "1 chocolate bar at £0.85"
            };

            var result = receiptCreator.CreateReceipt(items);

            Assert.Equal(3, result.PurchaseItems.Count);
            Assert.Equal(29.83m, result.Total);
            Assert.Equal(1.50m, result.SalesTaxes);
        }
    }
}
