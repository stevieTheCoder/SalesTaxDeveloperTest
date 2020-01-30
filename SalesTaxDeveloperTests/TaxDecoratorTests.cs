using SalesTaxDeveloperTest.Items;
using SalesTaxDeveloperTest.Services;
using Xunit;

namespace SalesTaxDeveloperTests
{
    public class TaxDecoratorTests
    {
        [Fact]
        public void AddTax_DoesNotAddTax_To_Books()
        {
            var taxDecorator = new TaxDecoratorService();

            var purchaseItem = new PurchaseItem("book", 12.49m);

            var withoutTax = taxDecorator.AddTax(purchaseItem);

            Assert.Equal(12.49m, withoutTax.GetPrice());
        }

        [Fact]
        public void AddTax_DoesNotAddTax_To_Food()
        {
            var taxDecorator = new TaxDecoratorService();

            var purchaseItem = new PurchaseItem("chocolate", 12.49m);

            var withoutTax = taxDecorator.AddTax(purchaseItem);

            Assert.Equal(12.49m, withoutTax.GetPrice());
        }

        [Fact]
        public void AddTax_DoesNotAddTax_To_Medical()
        {
            var taxDecorator = new TaxDecoratorService();

            var purchaseItem = new PurchaseItem("pills", 12.49m);

            var withoutTax = taxDecorator.AddTax(purchaseItem);

            Assert.Equal(12.49m, withoutTax.GetPrice());
        }

        [Fact]
        public void AddTax_DoesAddTax_To_CD()
        {
            var taxDecorator = new TaxDecoratorService();

            var purchaseItem = new PurchaseItem("music CD", 14.99m);

            var withoutTax = taxDecorator.AddTax(purchaseItem);

            Assert.Equal(16.49m, withoutTax.GetPrice());
        }

        [Fact]
        public void AddTax_DoesAddDuty_To_ImportedItems()
        {
            var taxDecorator = new TaxDecoratorService();

            // just import tax
            var purchaseItem = new PurchaseItem("imported box of chocolates", 10.00m);

            var withoutTax = taxDecorator.AddTax(purchaseItem);

            Assert.Equal(10.50m, withoutTax.GetPrice());
        }

        [Fact]
        public void AddTax_DoesAddDuty_AndTax_To_ImportedPerfume()
        {
            var taxDecorator = new TaxDecoratorService();

            // just import tax
            var purchaseItem = new PurchaseItem("imported bottle of perfume", 27.99m);

            var withoutTax = taxDecorator.AddTax(purchaseItem);

            Assert.Equal(32.19m, withoutTax.GetPrice());
        }
    }
}
